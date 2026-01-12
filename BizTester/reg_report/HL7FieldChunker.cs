using System;
using DiffPlex.DiffBuilder.Model;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;
using DiffPlex;
using System.Collections.Generic;
namespace BizTester.reg_report
{
    class HL7FieldChunker : IChunker
    {
        public IReadOnlyList<string> Chunk(string text)
        {
            if (string.IsNullOrEmpty(text))
                return Array.Empty<string>();

            var chunks = new List<string>(text.Length / 2);

            int start = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '|')
                {
                    if (i > start)
                        chunks.Add(text.Substring(start, i - start));

                    chunks.Add("|");
                    start = i + 1;
                }
            }

            if (start < text.Length)
                chunks.Add(text.Substring(start));

            return chunks;
        }
    }
}
