using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Linq;

namespace ITI.Algo.Tests
{
    class Exercise8
    {
        public void Zeroify(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            int[,] result = new int[size, size];

            for(int line = 0; line < size; line++)
            {
                for(int col = 0; col < size; col++)
                {
                    if (matrix[line, col] == 0)
                    {
                        matrix.SetValue(0, result[size, size]);
                    }     
                }
            }

            Array.Copy(result, matrix, result.Length);
        }

        public void ZeroifyProf(int[,] matrix)
        {
            HashSet<int> lineContainingZero = new HashSet<int>();
            HashSet<int> columnContainingZero = new HashSet<int>();

            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (matrix[x, y] == 0)
                    {
                        lineContainingZero.Add(x);
                        columnContainingZero.Add(y);
                    }
                }
            }

            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (lineContainingZero.Contains(x) || columnContainingZero.Contains(y))
                    {
                        matrix[x, y] = 0;
                    }
                }
            }
        }


        [Test]
        public void replace_with_zero()
        {
            int[,] matrix = { { 1, 2, 3, 4 }, { 0, 6, 7, 8 }, { 9, 10, 0, 12 } };
            ZeroifyProf(matrix);
            int[,] expected = { { 0, 2, 0, 4 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
            CollectionAssert.AreEqual(matrix, expected);
        }
    }
}
