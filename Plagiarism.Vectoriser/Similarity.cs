using System;

namespace Plagiarism.Vectoriser
{
    public class Similarity
    {
        /// <summary>
        /// Creates row wise cosine similarity from a 2-d matrix
        /// </summary>
        /// <param name="matrix">2-d matrix</param>
        /// <returns></returns>
        public double[,] CreateRowWise(double[,] matrix)
        {
            var similarityMatrix = new double[matrix.GetLength(0), matrix.GetLength(0)];

            for (var r1 = 0; r1 < matrix.GetLength(0); r1++)
            {
                for (var r2 = 0; r2 < matrix.GetLength(0); r2++)
                {
                    if (r1 == r2)
                    {
                        similarityMatrix[r1, r2] = 0;
                        continue;
                    }

                    var currentRow = new double[matrix.GetLength(1)];
                    var nextRow = new double[matrix.GetLength(1)];

                    for (var c = 0; c < matrix.GetLength(1); c++)
                    {
                        currentRow[c] = matrix[r1, c];

                        nextRow[c] = matrix[r2, c];
                    }

                    var sim = CosineSimilarity(currentRow, nextRow);

                    similarityMatrix[r1, r2] = sim;
                }
            }

            return similarityMatrix;
        }

        /// <summary>
        /// Creates cosine similarity from two vectors
        /// </summary>
        /// <param name="v1">vector1</param>
        /// <param name="v2">vector2</param>
        /// <returns></returns>
        public double CosineSimilarity(double[] v1, double[] v2)
        {
            var dotSum = 0.0;
            var v1SquaredSum = 0.0;
            var v2SquaredSum = 0.0;

            for (var i = 0; i < v1.Length; i++)
            {
                dotSum += v1[i] * v2[i];

                v1SquaredSum += v1[i] * v1[i];
                v2SquaredSum += v2[i] * v2[i];
            }

            return dotSum / (Math.Sqrt(v1SquaredSum) * Math.Sqrt(v2SquaredSum));
        }
    }
}
