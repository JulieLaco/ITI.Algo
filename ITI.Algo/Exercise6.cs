using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace ITI.Algo.Tests
{
    class Exercise6
    {
        private string IsCompressed(string input)
        {
            if (input.Length < 2) return input;

            StringBuilder sB = new StringBuilder();
            char previous = input[0];
            int count = 1;
            for (int i = 1; i < input.Length; i++)
            {
                char current = input[i];
                if (i == input.Length - 1)
                {
                    count++;
                    sB.Append(previous).Append(count);
                }
                else if (current != previous)
                {
                    sB.Append(previous).Append(count);

                    count = 1;
                    previous = current;
                }
                else
                {
                    count++;
                }

                if (sB.Length > input.Length) return input;
            }

            return sB.ToString();
        }

        //[TestCase("agghhhsssspp", "a1g2h3s4p2thbl")]
        //[TestCase("agghhhsssspp", "a1g2h3s4p2")]
        //[TestCase("aggHhhssssPp", "a1g2h3s4p2")]
        [TestCase("a", "a")]
        [TestCase("", "")]
        public void compression_test(string s1, string s2)
        {
            Assert.That(IsCompressed(s1), Is.EqualTo(s2));
        }
    }
}

