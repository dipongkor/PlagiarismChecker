using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlagiarismChecker.Pdf.Parser;

namespace Plagiarism.Vectoriser.Tests
{
    [TestClass]
    public class VectoriserTests
    {
        [TestMethod]
        public void CreateNGram()
        {
            var c = new Ngram();
            var ng = c.Create("This a sentence of my test", 3);
        }

        [TestMethod]
        public void CreateTfIdf()
        {
            var tfIdf = new TfIdf();

            var nGram = new Ngram();
            var pdfParser = new PdfParser();

            var reports = new Dictionary<string, List<string>>();

            foreach (var file in Directory.EnumerateFiles("Pdf", "*.pdf"))
            {
                var fileName = Path.GetFileNameWithoutExtension(file);

                var contents = pdfParser.GetText(file);

                reports[fileName] = nGram.Create(contents, 3);
            }

            var result =  tfIdf.Create(reports);

           var similarity = new Similarity();

           var sim = similarity.CreateRowWise(result);
        }

        [TestMethod]
        public void CosineSim()
        {
            var sim = new Similarity();

            double[] v1 = {1, 1, 1, 1, 0, 0, 0};
            double[] v2 = {1, 1, 1, 0, 1, 1, 1};

            var sim1 = sim.CosineSimilarity(v1, v2);
            var sim2 = sim.CosineSimilarity(v2, v1);
        }
    }
}
