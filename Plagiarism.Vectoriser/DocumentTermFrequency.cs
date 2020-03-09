using System.Collections.Generic;
using System.Linq;

namespace Plagiarism.Vectoriser
{
    public class DocumentTermFrequency
    {
        /// <summary>
        /// Creates document-term frequency
        /// </summary>
        /// <param name="documents">list of documents as dictionary</param>
        /// <returns></returns>
        public double[,] Create(Dictionary<string, List<string>> documents)
        {
            var allWords = new List<string>();
            var totalDocuments = documents.Keys.Count;

            int i = 0;
            foreach (var documentsValue in documents.Values)
            {
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                System.Diagnostics.Debug.Write($"Extracting document words for #{i++} ...");
                allWords.AddRange(documentsValue);
                System.Diagnostics.Debug.WriteLine($"completed in {sw.ElapsedMilliseconds}ms.");
            }

            var distinctTerms = allWords.Distinct().ToArray();
            var totalDistinctTerms = distinctTerms.Count();

            var tfIdfMatrix = new double[totalDocuments, totalDistinctTerms];
            

            for (var r = 0; r < totalDocuments; r++)
            {
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                System.Diagnostics.Debug.Write($"Processing document {r}...");
                
                for (var c = 0; c < totalDistinctTerms; c++)
                {
                    var key = documents.Keys.ElementAt(r);

                    var tf = (double) documents[key].Count(w => w == distinctTerms[c]);

                    tfIdfMatrix[r, c] = tf;
                }
                System.Diagnostics.Debug.WriteLine($"completed in {sw.ElapsedMilliseconds}ms.");
            }

            return tfIdfMatrix;
        }
    }
}