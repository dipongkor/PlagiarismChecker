using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace PlagiarismChecker.Pdf.Parser
{
    public class PdfParser : IPdfParser
    {
        public string GetText(string filePath)
        {
            using (var reader = new PdfReader(filePath))
            {
                var text = new StringBuilder();

                for (var i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
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
