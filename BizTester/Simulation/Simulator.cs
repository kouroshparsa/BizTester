﻿using HL7.Dotnetcore;
using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static BizTester.Simulation.SimulationSpec;

namespace BizTester.Simulation
{
    public class Simulator
    {
        private static readonly Random getrandom = new Random();
        private static int count = 0;
        
        private static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }
              
        private static string GetRecordValue(string val)
        {
            var gen = new PersonNameGenerator();
            if (val.Equals("{random_num}"))
                return GetRandomNumber(100000, 999999).ToString();
            else if (val.Equals("{random_last_name}"))
                return gen.GenerateRandomLastName();
            else if (val.Equals("{random_first_name}"))
                return gen.GenerateRandomFirstName();
            else if (val.Equals("{now}"))
                return GetCurrentDateTime();
            else if (val.Contains("{count}"))
                return val.Replace("{count}", count.ToString());
            return val;

        }

        public static string GetHL7Message(SimulationSpec spec)
        {
            string sampleData = GetHL7Message_NoSample(spec.records);
            return GetHL7Message_WithSample(spec.records, sampleData);
        }
        public static string GetHL7Message_WithSample(List<Record> records, string sampleData)
        {
            sampleData = sampleData.Trim();
            if (sampleData.Length < 1)
            {
                throw new Exception("You need to specify a sample HL7 seed file.");
            }
            count += 1;
            var msg = new Message(sampleData);
            msg.ParseMessage();// Do not check the result. It sometimes returns false for valid messages

            foreach (Record record in records)
            {
                string val = GetRecordValue(record.Value);
                string segName = record.Field.Split('.')[0];
                if (msg.Segments(segName).Count > 0)
                {
                    var parts = record.Field.Split('.');
                    int fieldIndex = 0;
                    int componentIndex = 0;
                    if (parts.Length > 1)
                    {
                        fieldIndex = int.Parse(parts[1]);
                        if (parts.Length > 2)
                        {
                            componentIndex = int.Parse(parts[2]);
                        }
                    }

                    foreach (Segment seg in msg.Segments(segName)) {
                        var fields = seg.GetAllFields();
                        if(fieldIndex > 0)
                        {
                            Field field = seg.Fields(fieldIndex);
                            if (field == null) {
                                field = new Field($"{segName}.{fieldIndex}", new HL7Encoding());
                                seg.AddNewField(field, fieldIndex);
                            }
                            // Get or create the component PID.5.1
                            if(componentIndex > 0)
                            {
                                if (field.Components().Count < componentIndex)
                                {
                                    field.AddNewComponent(new Component(val, new HL7Encoding()));
                                }
                                else
                                {
                                    field.Components(componentIndex).Value = val;
                                }
                            }else
                            {
                                field.Value = val;
                            }

                        }

                    }
                }
            }
            return msg.SerializeMessage(false);

        }
        public static string GetHL7Message_NoSample(List<Record>records)
        {
            // Do not subsitute value in this method. Let GetHL7Message_WithSample do the substitution
            var msg = new Message();
            var segments = new Dictionary<string, Segment>();
            var fields = new Dictionary<string, Field>();
            var gen = new PersonNameGenerator();

            string sendingApp = "SendingApp";
            string sendingFacility = "Hospital1";
            string receivingApp = "ReceivingApp";
            string receivingFacility = "Hospital2";
            string messageType = "ADT";
            string eventType = "A03";
            string messageControlID = $"MSGID{count}";
            string processingID = "P";
            string version = "2.4";
            List<Record> headerCustomData = new List<Record>();
            bool isHeaderAdded = false;

            foreach (Record record in records)
            {
                string val = record.Value;
                if (record.Field.StartsWith("MSH."))
                {
                    switch (record.Field)
                    {
                        case "MSH.3":
                            sendingApp = val;
                            break;
                        case "MSH.4":
                            sendingFacility = val;
                            break;
                        case "MSH.5":
                            receivingApp = val;
                            break;
                        case "MSH.6":
                            receivingFacility = val;
                            break;
                        case "MSH.9.1":
                            messageType = val;
                            break;
                        case "MSH.9.2":
                            eventType = val;
                            break;
                        case "MSH.11":
                            processingID = val;
                            break;
                        case "MSH.12":
                            version = val;
                            break;
                        default:
                            record.Value = val;
                            headerCustomData.Add(record);
                            break;
                    }
                    continue;

                }else if(!isHeaderAdded)
                {
                    msg.AddSegmentMSH(sendingApp, sendingFacility, receivingApp, receivingFacility, "", $"{messageType}^{eventType}", messageControlID, processingID, version);
                    foreach (Record rec in headerCustomData)
                    {
                        int msh_index = int.Parse(rec.Field.Split('.')[1]);
                        msg.Segments("MSH")[0].AddNewField(new Field(rec.Value, new HL7Encoding()), msh_index);
                    }
                    isHeaderAdded = true;
                }
                
                if (new Regex(@"^\w+\.\d+$").IsMatch(record.Field))// field
                {
                    var field = new Field(val, new HL7Encoding());
                    fields.Add(record.Field, field);
                    string[] seg_field = record.Field.Split('.');
                    int field_index = int.Parse(seg_field[1]);
                    if (segments.ContainsKey(seg_field[0])) {
                        segments[seg_field[0]].AddNewField(field);

                    }else{
                        var seg = new Segment(seg_field[0], new HL7Encoding());
                        segments.Add(seg_field[0], seg);
                        seg.AddNewField(field, field_index);
                        msg.AddNewSegment(seg);
                    }

                } else if (new Regex(@"^\w+\.\d+\.\d+$").IsMatch(record.Field)) {// component
                    
                    Component comp = new Component(val, new HL7Encoding());
                    string[] seg_field_comp = record.Field.Split('.');
                    int field_index = int.Parse(seg_field_comp[1]);
                    int comp_index = int.Parse(seg_field_comp[2]);
                    Segment seg;
                    if (segments.ContainsKey(seg_field_comp[0]))
                    {
                        seg = segments[seg_field_comp[0]];

                    }
                    else
                    {
                        seg = new Segment(seg_field_comp[0], new HL7Encoding());
                        segments.Add(seg_field_comp[0], seg);
                        msg.AddNewSegment(seg);
                    }

                    Field field;
                    if (fields.ContainsKey(seg_field_comp[1]))
                    {
                        field = fields[seg_field_comp[1]];

                    }
                    else
                    {
                        field = new Field(seg_field_comp[1], new HL7Encoding());
                        fields.Add(seg_field_comp[1], field);
                        seg.AddNewField(field, field_index);
                    }

                    field.AddNewComponent(comp, comp_index);
                }
                
            }
            
            return msg.SerializeMessage(false);
        }

        private static string GetCurrentDateTime()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss.FFFF");
        }
    }

}
