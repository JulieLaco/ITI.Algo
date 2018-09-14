using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Linq;

namespace ITI.Algo.Tests
{
    class Exercise9
    {
        public bool IsRotation(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            int startIndex = s1.IndexOf(s1);
            int endIndex = s1.LastIndexOf(s1);
            int length = endIndex - startIndex + 2;

            //for(int x = 0; x < s1.Length; x++)
            //{

            //}

            var result = s1.Substring(startIndex, length);

            s2 = result;

            return true;


        }

        public bool IsRotationProf(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;
            return IsSubstring(s1 + s1, s2);
        }

        bool IsSubstring(string s1, string s2)
        {
            return s1.Contains(s2);
        }

        [TestCase("hello", "lohel", true)]
        [TestCase("hello", "hello", true)]
        [TestCase("hello", "llohe", true)]
        [TestCase("hello", "licorne", false)]
        [TestCase("hello", "hel", false)]
        [TestCase("hello", "hellosir", false)]
        public void isSubstring_rotate(string s1, string s2, bool expected) 
        {
            Assert.That(IsRotation(s1, s2), Is.EqualTo(expected));
            Assert.That(IsRotationProf(s1, s2), Is.EqualTo(expected));
        }
    }
}
