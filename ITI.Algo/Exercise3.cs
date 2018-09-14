using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace ITI.Algo.Tests
{
    class Exercise3
    {
        public static void URLifie(char[] charArray)
        {
            int whitespaceCount = 0;
            int count = 0;

            foreach (char c in charArray)
            {
                if (c == 0) break;
                if (char.IsWhiteSpace(c)) whitespaceCount++;
                count++;      
            }

            if (whitespaceCount == 0) return;

            for (int x = count - 1; x >= 0; x--)
            {
                if (char.IsWhiteSpace(charArray[x]))
                {
                    charArray[x + whitespaceCount * 2 - 2] = '%';
                    charArray[x + whitespaceCount * 2 - 1] = '2';
                    charArray[x + whitespaceCount * 2] = '0';        
                    whitespaceCount--;
                }
                else
                {
                    charArray[x + whitespaceCount * 2] = charArray[x];
                }
            }
        }

        [TestFixture]
        public class Exercise3Tests
        {
            [TestCase("abc d efg h i j")]
            [TestCase("xyz abcd efg")]
            [TestCase("    ")]
            public void URLifieTest(string input)
            {
                string expected = input.Replace(" ", "%20");
                char[] chars = new char[expected.Length];
                input.CopyTo(0, chars, 0, input.Length);
                URLifie(chars);

                CollectionAssert.AreEqual(chars, expected);
            }
        }
    }
}
