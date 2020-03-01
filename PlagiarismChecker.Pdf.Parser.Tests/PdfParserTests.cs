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

            Assert.AreEqual(text, "atish kumar dipongkor");
        }
    }
}
