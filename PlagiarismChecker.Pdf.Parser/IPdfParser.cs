using System.Collections.Generic;

namespace PlagiarismChecker.Pdf.Parser
{
    public interface IPdfParser
    {
        string GetText(string filePath);
    }
}
