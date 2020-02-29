using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plagiarism.Vectoriser;
using PlagiarismChecker.Pdf.Parser;

namespace PlagiarismChecker.Tests
{
    [TestClass]
    public class PlagiarismCheckerTests
    {
        [TestMethod]
        public void GetSimilarity()
        {
            var pdfParser = new PdfParser();
            var tfIdf = new TfIdf();
            var nGram = new Ngram();

            var reports = new Dictionary<string, List<string>>
            {
                //{"1", nGram.Create("This is a sentence x", 2) },
                //{"2", nGram.Create("This is a sentence x", 2) },
                //{"3", nGram.Create("This is a sentence x", 2) }
            };


            foreach (var file in Directory.EnumerateFiles(@"C:\Users\User\source\repos\PlagiarismChecker\PlagiarismChecker.Tests\Reports", "*.pdf"))
            {
                var contents = pdfParser.GetText(file);

                reports[file] = nGram.Create(contents, 5);
            }

            var tfIdfMatrix = tfIdf.Create(reports);

            var sim = new Similarity().CreateRowWise(tfIdfMatrix);

            var strBuilder = new StringBuilder();
            for (int r = 0; r < sim.GetLength(0); r++)
            {
                var line = "";
                for (int c = 0; c < sim.GetLength(1); c++)
                {
                    if (c == sim.GetLength(1) - 1)
                        line += sim[r, c];
                    else
                    {
                        line += $"{sim[r, c]},";
                    }
                }

                strBuilder.AppendLine(line);
            }

            var csv = strBuilder.ToString();
        }
    }
}
