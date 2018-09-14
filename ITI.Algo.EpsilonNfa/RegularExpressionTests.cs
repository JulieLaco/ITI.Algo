using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Linq;
using ITI.Algo.RegularExpression;

namespace ITI.Algo.EpsilonNfa
{
    [TestFixture]
    public class RegularExpressionTests
    {
        [TestCase("(ab)|(c*d)", "cccd", true)]
        [TestCase("(ab)|(c*d)", "ccdd", false)]
        public void regular_test(string input, string result, bool expected)
        {

        }

        [TestCase("ab|c", "(| (+ a b) c)")]
        [TestCase("ab|c*", "(| (+ a b) (c))")]
        [TestCase("a(b|c)*", "(+ a (* (| b c)))")]
        [TestCase("(ab|xc)*", "(* (| (+ a b) (+ x c)))")]
        public void parsing(string regex, string expected)
        {
            ProfParser p = new ProfParser(regex);
            ProfNode ast = p.Parse();
            Assert.That(ast.ToString(), Is.EqualTo(expected));
        }
    }
}
