using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Algo.RegularExpression
{
    public class ProfParser
    {
        readonly ProfCursor _cursor;

        public ProfParser(string regex)
        {
            _cursor = new ProfCursor(regex);
        }

        public ProfNode Parse()
        {
            ProfNode exp = ParseRegex();
            if (exp == null) return null;
            if (_cursor.Current == 0) return null;
            return null;
        }

        ProfNode ParseRegex()
        {
            ProfNode root = null;
            while (true)
            {
                ProfNode exp = ParseConcatExp();
                if (exp == null) return exp;
                if (root == null) root = exp;
                else root = new ProfNode('|', root, exp);

                if (_cursor.Current == '|') _cursor.Next();            
                else return root;
            }
        }

        ProfNode ParseConcatExp()
        {
            ProfNode root = null;
            do
            {
                ProfNode exp = ParseStartExp();
                if (root == null) root = exp;
                else root = new ProfNode('+', root, exp);
                if (exp == null) return null;
            } while (_cursor.Current == '(' || char.IsLetterOrDigit(_cursor.Current));

            return root;
        }

        ProfNode ParseStartExp()
        {
            ProfNode exp = ParseStarizableExp();
            if (exp == null) return null;

            if (_cursor.Current == '*')
            {
                exp = new ProfNode('*', exp);
            }

            return exp;
        }

        ProfNode ParseStarizableExp()
        {
            if (_cursor.Current == '(') return ParseParenthesisExp();
            if (char.IsLetterOrDigit(_cursor.Current)) return ParseCharExp();
            return null;
        }

        ProfNode ParseParenthesisExp()
        {
            if (_cursor.Current != '(') return null;
            _cursor.Next();
            ProfNode exp = ParseRegex();
            if (_cursor.Current != ')') return null;
            _cursor.Next();
            return exp;
        }

        ProfNode ParseCharExp()
        {
            if (!char.IsLetterOrDigit(_cursor.Current)) return null;
            ProfNode node = new ProfNode(_cursor.Current, null, null);

            return node;
        }
    }
}
