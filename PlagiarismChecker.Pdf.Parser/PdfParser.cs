using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

namespace PlagiarismChecker.Pdf.Parser
{
    public class PdfParser : IPdfParser
    {
        public string GetText(string filePath)
        {
            using (var reader = new PdfReader(filePath))
            {
                using(var pdfDoc = new PdfDocument(reader))
                {
                    var text = new StringBuilder();

                    for (var page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
                    {
                        var strategy = new SimpleTextExtractionStrategy();
                        var pageContent = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page), strategy);
                        text.Append(pageContent);
                    }

                    var fileTextWithoutNewLine = new Regex("[\r\n]+").Replace(text.ToString(), " ");

                    var fileText = new Regex("[^a-zA-Z0-9 -]").Replace(fileTextWithoutNewLine, "");

                    var regex = new Regex("[^\\s]+");

                    var words = regex.Matches(fileText).Cast<Match>().Select(m => m.Value.ToLower());

                    return string.Join(" ", words);
                }
            }
        }
    }
}
