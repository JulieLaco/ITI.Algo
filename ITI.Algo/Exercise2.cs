using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ITI.Algo.Tests
{
    class Exercise2
    {
        public static bool IsPermutation (string s1, string s2)
        {               
            if (s1.Length != s2.Length) return false;

            return string.Concat(s1.OrderBy(c => c)) == string.Concat(s2.OrderBy(c => c));
        }

        public static bool IsPermutationV2 (string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            Dictionary<char, int> s1Frequency = Frequency(s1);

            // Complexité linéaire (lié à la taille de la chaine de caractère s2)
            // On parcours s2 
            // On décremente et si rien on sort
            foreach (char c in s2)
            {
                int n;
                if (!s1Frequency.TryGetValue(c, out n) || n == 0) return false;
                s1Frequency[c] = n - 1;
            }

            return true;
        }

        // Complexité linéaire
        static Dictionary<char, int> Frequency(string s)
        {
            Dictionary<char, int> result = new Dictionary<char, int>();

            foreach( char c in s )
            {
                int n;
                if (result.TryGetValue(c, out n)) result[c] = n + 1;
                else result[c] = 1;
            }

            return result;
        }

        [TestFixture]
        public class Exercise2Tests
        {
            [TestCase("abc", "abc", true)]
            [TestCase("abc", "acb", true)]
            [TestCase("acb", "bac", true)]
            [TestCase("bac", "bca", true)]
            [TestCase("bca", "cab", true)]
            [TestCase("cab", "cba", true)]
            [TestCase("cba", "cca", false)]
            [TestCase("", "", true)]
            [TestCase("xxy", "xyy", false)]
            [TestCase("xxy", "xyyy", false)]
            [TestCase("abcd", "abcddddd", false)]
            public void permutation(string s1, string s2, bool expected)
            {
                Assert.That(IsPermutation(s1, s2), Is.EqualTo(expected));
                Assert.That(IsPermutationV2(s1, s2), Is.EqualTo(expected));
                
            }
        }
    }
}
