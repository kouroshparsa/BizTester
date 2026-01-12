using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.XLANGs.BaseTypes;
using System.Xml.Xsl;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BizTester.Models;

namespace BizTester.Helpers
{
    class BiztalkMapExecutor
    {
        private static List<HelperAssemblyInfo> GetHeplerAssemblies(string mapFile, string dllFolder)
        {
            var assemblies = new List<HelperAssemblyInfo>();
            // <Script Language="ExternalAssembly" Assembly="" Class="" .../>
            string content = File.ReadAllText(mapFile);
            var matches = Regex.Matches(
                content,
                @"<Script\s+.*Language=""ExternalAssembly""[^>]*/>",
                RegexOptions.IgnoreCase | RegexOptions.Singleline
            );

            int num = 0;
            foreach (Match match in matches)
            {
                string ns = $"http://schemas.microsoft.com/BizTalk/2003/ScriptNS{num}";
                int ind = match.Value.IndexOf("Class=") + 7;
                int ind2 = match.Value.IndexOf("\"", ind + 1);
                string className = match.Value.Substring(ind, ind2 - ind);
                assemblies.Add(new HelperAssemblyInfo(className, ns, dllFolder));
                num++;
            }
            return assemblies;
        }

        private static bool InheritsFromTransformBase(Type t)
        {
            while (t != null)
            {
                if (t.FullName == "Microsoft.XLANGs.BaseTypes.TransformBase")
                    return true;
                t = t.BaseType;
            }
            return false;
        }
        public static void ApplyBizTalkMap(string inputXmlPath, string mapDllPath, string outputPath, string mapPath, string dllFolder)
        {
            var assemblies = GetHeplerAssemblies(mapPath, dllFolder);
            string inputXml = File.ReadAllText(inputXmlPath);

            var xdoc = XDocument.Parse(inputXml);
            var root = xdoc.Root;

            string inputRootLocal = root.Name.LocalName;
            string inputRootNs = root.Name.NamespaceName;

            // Load Map Assembly
            var asm = Assembly.LoadFrom(mapDllPath);

            // Find all map types by inheritance *name*, not type identity
            var mapTypes = asm.GetTypes()
                .Where(t => !t.IsAbstract && InheritsFromTransformBase(t))
                .ToList();

            Type selectedMapType = null;
            string selectedXslt = null;

            foreach (var mapType in mapTypes)
            {
                // Create instance WITHOUT casting
                var mapInstance = Activator.CreateInstance(mapType);

                // Read XmlContent via reflection
                var xmlContentProp = mapType.GetProperty(
                    "XmlContent",
                    BindingFlags.Public | BindingFlags.Instance
                );

                if (xmlContentProp == null)
                    continue;

                string xslt = xmlContentProp.GetValue(mapInstance) as string;

                if (string.IsNullOrWhiteSpace(xslt))
                    continue;

                // Parse XSLT
                var xsltDoc = XDocument.Parse(xslt);

                var matches = xsltDoc
                    .Descendants()
                    .Where(e =>
                        e.Name.LocalName == "template" &&
                        e.Attribute("match") != null
                    );

                foreach (var match in matches)
                {
                    var matchValue = match.Attribute("match")?.Value;

                    if (!string.IsNullOrEmpty(matchValue) &&
                        matchValue.Contains(inputRootLocal))
                    {
                        selectedMapType = mapType;
                        selectedXslt = xslt;

                        Console.WriteLine($"Selected Map: {mapType.FullName}");
                        break;
                    }
                }

                if (selectedMapType != null)
                    break;
            }

            if (selectedMapType == null || selectedXslt == null)
            {
                throw new Exception(
                    $"No BizTalk map found that matches input XML root node.\n" +
                    $"inputXmlPath={inputXmlPath}\n" +
                    $"mapDllPath={mapDllPath}\n" +
                    $"mapPath={mapPath}\n" +
                    $"dllFolder={dllFolder}"
                );
            }
            // Load input XML to detect root node + namespace
            /*
            var xdoc = XDocument.Parse(inputXml);
            var root = xdoc.Root;

            string inputRootLocal = root.Name.LocalName;
            string inputRootNs = root.Name.NamespaceName;

            // Load Map Assembly
            var asm = Assembly.LoadFrom(mapDllPath);

            // Find all TransformBase implementations
            var mapTypes = asm.GetTypes()
                .Where(t => !t.IsAbstract && InheritsFromTransformBase(t))
                .ToList();
            TransformBase selectedMap = null;

            foreach (var mapType in mapTypes)
            {
                TransformBase mapInstance = (TransformBase)Activator.CreateInstance(mapType);
               string xslt = mapInstance.XmlContent;  // Extract XSLT text

                if (string.IsNullOrWhiteSpace(xslt))
                    continue;

                // Parse XSLT to get the match root node
                var xsltDoc = XDocument.Parse(xslt);

                var matches = xsltDoc
                    .Descendants()
                    .Where(e => e.Name.LocalName == "template" &&
                                e.Attribute("match") != null);

                foreach (var match in matches)
                {
                    var matchValue = match.Attribute("match")?.Value;

                    if (!string.IsNullOrEmpty(matchValue) &&
                        matchValue.Contains(inputRootLocal))
                    {
                        // e.g. "/ns1:ADT_UCIMEMDT_25_GLO_DEF"
                        selectedMap = mapInstance;
                        Console.WriteLine($"Selected Map: {mapType.FullName}");
                        break;
                    }
                }
                
            }

            if (selectedMap == null)
                throw new Exception($"No BizTalk map found that matches input XML root node.\ninputXmlPath={inputXmlPath}\nmapDllPath={mapDllPath}\nmapPath={mapPath}\ndllFolder={dllFolder}");

            var args = new XsltArgumentList();

            // load helpers:
            foreach(var info in assemblies)
            {
                var helperAsm = Assembly.LoadFrom(info.AssemblyPath);
                var helperType = helperAsm.GetType(info.Class, throwOnError: true); // get the class name from the btm file. Example: <Script Language="ExternalAssembly" Assembly="FH.UCI.ME.Helper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=19bb8b5ea64396aa" Class="FH.UCI.ME.Helper.UCIHelper" Function="getCurrentTimeWithOffset"/>
                var helperInstance = Activator.CreateInstance(helperType);

                // you will need to get the namespace end part from your xslt like so: <xsl:variable name="var:v3" select="ScriptNS0:getCurrentTimeWithOffset()" />
                args.AddExtensionObject(
                    info.Namespace,
                    helperInstance
                );
            }
            

            var transform = new XslCompiledTransform();

            var settings = new XsltSettings(enableDocumentFunction: true, enableScript: true);
            var resolver = new XmlUrlResolver();
            using (var xsltReader = XmlReader.Create(new StringReader(selectedMap.XmlContent)))
            {
                transform.Load(xsltReader, settings, resolver);
            }

            string directory = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var xmlSettings = transform.OutputSettings.Clone();
            xmlSettings.Indent = true;
            xmlSettings.IndentChars = "  ";   // or "\t"
            xmlSettings.NewLineChars = Environment.NewLine;
            xmlSettings.NewLineHandling = NewLineHandling.Replace;

            using (var inputReader = XmlReader.Create(inputXmlPath))
            using (var writer = XmlWriter.Create(outputPath, xmlSettings))
            {
                transform.Transform(inputReader, args, writer);
            }
            */
        }

    }
}
