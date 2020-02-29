using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlagiarismChecker.Pdf.Parser.Tests
{
    [TestClass]
    public class PdfParserTests
    {
        [TestMethod]
        public void GetText()
        {
            var pdfParser = new PdfParser();

            var text = pdfParser.GetText("PdfFiles/1.pdf");

            Assert.AreEqual("Atish Kumar Dipongkor", text);
        }

        [TestMethod]
        public void GetText2()
        {
            var pdfParser = new PdfParser();

            var text = pdfParser.GetText("PdfFiles/2.pdf");

            Assert.AreEqual("Atish Kumar Dipongkor", text);
        }
    }
}
