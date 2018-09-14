using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Algo.RegularExpression
{
    public class ProfCursor
    {
        readonly string _s;
        int _pos;
        int _idx;
        char _current;

        public ProfCursor(string s)
        {
            _s = s ?? string.Empty;
        }

        public char Current
        {
            get { return Lookahead(0); }
        }

        public void Next()
        {
            _pos++;
        }

        public char Lookahead(int n)
        {
            if (_idx + n >= _s.Length) return (char)0;
            return _s[_current + n];
        }
    }
}
