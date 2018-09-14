using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace ITI.Algo.Tests
{
    class Exercise7
    {
        public void Rotate(int[,] oldM)
        {
            int[,] newM = new int[oldM.GetLength(1), oldM.GetLength(0)];

            int newColumn = 0;
            int newRow = 0;

            for(int oldColum = oldM.GetLength(1) - 1; oldColum >= 0; oldColum--)
            {
                newColumn = 0;
                for(int oldRow = 0;  oldRow < oldM.GetLength(0); oldRow++)
                {
                    newM[newColumn, newRow] = oldM[oldColum, oldRow];
                    newColumn++;
                }
                newRow++;
            }

            oldM = newM;
        }

        public void Rotate2(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            int[,] result = new int[size, size];

            for (int line = 0; line < size; line++)
            {
                for (int col = 0; col < size; col++)
                {
                    result[col, size - line - 1] = matrix[line, col];
                }
            }

            Array.Copy(result, matrix, result.Length);
        }

        [Test]
        public void rotate()
        {
            int[,] matrix = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            //Rotate(matrix);
            Rotate2(matrix);

            int[,] expected = { { 13, 9, 5, 1 }, { 14, 10, 6, 2 }, { 15, 11, 7, 3 }, { 16, 12, 8, 4 } };

            CollectionAssert.AreEqual(matrix, expected);
        }
    }
}
