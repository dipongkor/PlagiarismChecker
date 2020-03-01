using System.Collections.Generic;

namespace Plagiarism.Vectoriser
{
    public class Ngram
    {
        /// <summary>
        /// Creates n-gram from sentence(s)
        /// </summary>
        /// <param name="input">sentence(s)</param>
        /// <param name="n">size of n gram</param>
        /// <returns></returns>
        public List<string> Create(string input, int n)
        {
            var nGrams = new List<string>();

            var words = input.Split(' ');

            if (words.Length <= n)
            {
                nGrams.Add(string.Join(" ", words));
                return nGrams;
            }

            for (var w = 0; w < words.Length; w++)
            {
                if (w + n > words.Length) break;

                var nGramElements = new List<string>();

                for (var i = w; i < w + n; i++)
                {
                    nGramElements.Add(words[i]);
                }

                nGrams.Add(string.Join(" ", nGramElements));
            }

            return nGrams;
        }
    }
}
