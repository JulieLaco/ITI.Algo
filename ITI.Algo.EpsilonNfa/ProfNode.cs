using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Algo.RegularExpression
{
    public class ProfNode
    {
        readonly char _symbol;
        readonly ProfNode _left;
        readonly ProfNode _right;

        public ProfNode(char symbol)
            : this(symbol, null)
        {

        }

        public ProfNode(char symbol, ProfNode left, ProfNode right)
        {
            _symbol = symbol;
            _left = left;
            _right = right;
        }

        public ProfNode(char symbol, ProfNode left)
            : this(symbol, left, null)
        {

        }

        public char Symbol { get { return _symbol; } }
        public ProfNode Left { get { return _left; } }
        public ProfNode Right { get { return _right; } }

        public override string ToString()
        {
            if (char.IsLetterOrDigit(_symbol)) return _symbol.ToString();
            if (_symbol == '*') return string.Format("(* {0})", _left);
            return string.Format("({0} {1} {2})", _symbol, _left, _right);
        }
    }
}
