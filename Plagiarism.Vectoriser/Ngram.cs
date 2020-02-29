using System.Collections.Generic;

namespace Plagiarism.Vectoriser
{
    public class Ngram
    {
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
