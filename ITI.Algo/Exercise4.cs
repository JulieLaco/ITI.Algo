using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ITI.Algo.Tests
{
    class Exercise4
    {
        public static bool IsPalindromePermutation(string s)
        {
           return s.GroupBy(c => c).Count(g => g.Count() % 2 == 1) <= 1;          
        }

        [TestFixture]
        public class Exercise4Tests
        {
            [TestCase("anan", true)]
            [TestCase("coocl", true)]
            [TestCase("kaayk", true)]
            [TestCase("abcd", false)]
            [TestCase("anansi", false)]
            [TestCase("azerty", false)]
            public void palindrome_permutation(string s1, bool expected)
            {
                Assert.That(IsPalindromePermutation(s1), Is.EqualTo(expected));
            }
        }
    }
}
