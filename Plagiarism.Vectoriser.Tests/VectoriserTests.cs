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
            var ngram = new Ngram();
            var words = ngram.Create("This a sentence of my test", 3);
            CollectionAssert.AreEqual(words, new List<string> { "This a sentence", "a sentence of", "sentence of my", "of my test" });
        }

        [TestMethod]
        public void CreateTfIdf()
        {
            var tfIdf = new DocumentTermFrequency();

            var nGram = new Ngram();
            var pdfParser = new PdfParser();

            var reports = new Dictionary<string, List<string>>();

            foreach (var file in Directory.EnumerateFiles("Pdf", "*.pdf"))
            {
                var fileName = Path.GetFileNameWithoutExtension(file);

                var contents = pdfParser.GetText(file);

                reports[fileName] = nGram.Create(contents, 3);
            }

            var result = tfIdf.Create(reports);
            Assert.AreEqual(result.GetLength(0), 2);
            Assert.AreEqual(result.GetLength(1), 7);
        }

        [TestMethod]
        public void CosineSimilarity()
        {
            var sim = new Similarity();

            double[] v1 = { 1, 1, 1, 1, 0, 0, 0 };
            double[] v2 = { 1, 1, 1, 0, 1, 1, 1 };

            var sim1 = sim.CosineSimilarity(v1, v2);
            Assert.AreEqual(sim1, 0.61237243569579458);
        }
    }
}
