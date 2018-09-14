using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Linq;

namespace ITI.Algo.Tests
{
    class Exercise5
    {
        public static bool IsChanged(string s1, string s2)
        {
            if (s1 == s2) return true;
            if (Math.Abs(s1.Length - s2.Length) > 1) return false;

            if (s1.Length == s2.Length)
            {
                int diff = 0;
                for (int x = 0; x < s1.Length; x++)
                {
                    if (s1[x] != s2[x] && ++diff > 1) return false;
                }

                return true;
            }
            if (s2.Length > s1.Length)
            {
                string tmp = s1;
                s1 = s2;
                s2 = tmp;
            }

            int offset = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (i == s1.Length - 1 && offset == 0) return true;
                if (s1[i] != s2[i + offset] && offset-- != 0) return false;
            }

            return true;
        }

        [TestFixture]
        public class Exercise5Tests
        {
            [TestCase("abba", "abba", true)]
            [TestCase("abba", "abbajour", false)]
            [TestCase("abba", "abbau", true)] // Add
            [TestCase("abba", "abb", true)] // Delete
            [TestCase("abba", "ab", false)]
            [TestCase("abba", "abla", true)] // Substitution
            [TestCase("abba", "alla", false)]
            public void test5(string s1, string s2, bool expected)
            {
                Assert.That(IsChanged(s1, s2), Is.EqualTo(expected));
            }
        }
    }
}
