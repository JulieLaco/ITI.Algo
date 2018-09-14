using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Algo.RegularExpression
{
    public enum TokenType
    {
        OpenBracket, // (
        CloseBracket, // )
        OpenCurlyBracket, // {
        CloseCurlyBracket, // }
        OpenSquareBracket, // [
        CloseSquareBracket, // ]
        Pipe, // |
        Kleene, // *
        Char // 
    }
}
