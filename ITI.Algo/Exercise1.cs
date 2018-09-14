using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace ITI.Algo.Tests
{
    class Exercise1
    {
        public static bool CheckV1 (string s)
        {
            // Code Impératif (paradigme)
            HashSet<char> seenCharacters = new HashSet<char>();

            foreach (char c in s)
            {
                if (seenCharacters.Contains(c)) return false;
                seenCharacters.Add(c);
            }

            return true;
        }

        public static bool CheckV2 (string s)
        {
            // LINQ
            return !s.GroupBy(c => c).Any(g => g.Count() != 1);
        }

        public static bool CheckV3 (string s)
        {
            // Complexité en n au carré
            int tmp = 0;
            for (int x = 0; x < s.Length; x++)
            {
                for (int y = x + 1; y < s.Length; y++)
                {
                    tmp++;
                    System.Console.WriteLine(tmp);
                    if (s[x] == s[y]) return false;
                }
            }

            return true;
        }

        [TestFixture]
        public class Exercise1Tests
        {
            //[TestCase("abcde", true)]
            //[TestCase("abcdea", false)]
            //[TestCase("", true)]
            //[TestCase("   ", false)]
            [TestCase("a", true)]
            [TestCase("ab", true)]
            [TestCase("abc", true)]
            [TestCase("abcd", true)]
            [TestCase("abcde", true)]
            [TestCase("abcdef", true)]
            [TestCase("abcdefg", true)]
            [TestCase("abcdefgh", true)]
            [TestCase("abcdefghi", true)]
            [TestCase("abcdefghij", true)]
            [TestCase("abcdefghijk", true)]
            [TestCase("abcdefghijkl", true)]
            [TestCase("abcdefghijklm", true)]
            [TestCase("abcdefghijklmn", true)]
            public void test1 (string input, bool expected)
            {
                Assert.That(Exercise1.CheckV1(input), Is.EqualTo(expected));
                Assert.That(Exercise1.CheckV2(input), Is.EqualTo(expected));
                Assert.That(Exercise1.CheckV3(input), Is.EqualTo(expected));
            }
        }
    }
}
