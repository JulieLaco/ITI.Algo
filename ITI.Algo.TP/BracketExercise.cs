using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Linq;

namespace ITI.Algo.TP
{
    // https://tinyurl.com/ydgc4bjw
    [TestFixture]
    public class BracketExercise
    {
        bool Check(string input)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in input)
            {
                if (c == '{' || c == '(' || c == '[')
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count == 0) return false;
                    char top = stack.Pop();
                    if (c == '}' && top != '{') return false;
                    if (c == ')' && top != '(') return false;
                    if (c == ']' && top != '[') return false;
                }
            }
            return stack.Count == 0;
        }

        bool RecCheck(string input)
        {
            int n;
            return ValidExpr(input, 0, out n);
        }

        bool ValidExpr(string input, int start, out int index)
        {
            index = start;
            while (index < input.Length)
            {
                if (!ParExpr(input, index, out index)) return false;
            }
            return true;
        }

        bool ParExpr(string input, int start, out int index)
        {
            index = start;
            if (input[start] != '(') return false;
            if (input[start + 1] == '(' && !ValidExpr(input, start + 1, out index)) return false;
            if (input[index] != ')') return false;
            index++;
            return true;
        }

        [TestCase("()()", true)]
        //[TestCase( "()", true )]
        //[TestCase( "(())", true )]
        //[TestCase( "(()())", true )]
        //[TestCase( "(()())(())", true )]
        //[TestCase( "(()(()))(())", true )]
        //[TestCase( "(()(()()))(())", true )]
        //[TestCase( "(()(()()))())", false )]
        //[TestCase( "(()(()())(())", false )]
        //[TestCase( "()(()()))(())", false )]
        //[TestCase( "(()(()()))(()", false )]
        //[TestCase( "[]", true )]
        //[TestCase( "[()]", true )]
        //[TestCase( "[()]()", true )]
        //[TestCase( "[()]({})", true )]
        //[TestCase( "[({{}})]({})", true )]
        //[TestCase( "[({{}})[]]({})", true )]
        //[TestCase( "[({{}})[]]({((()))})", true )]
        //[TestCase( "[({{}})[]]({((()))})({[]})", true )]
        //[TestCase( "[({{(}}))[]]({((()))})({[]})", false )]
        //[TestCase( "[({{}})[]]({((()))})({[]}))", false )]
        //[TestCase( "([({{}})[]]({((()))})({[]})", false )]
        public void tests(string input, bool expected)
        {
            Assert.That(Check(input), Is.EqualTo(expected));
            Assert.That(RecCheck(input), Is.EqualTo(expected));
        }
    }
}
