using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Algo.RegularExpression
{
    public class NodeExpression : Node
    {
        public Node Alternative { get; set; }

        public TokenType TokenType { get; }
    }
}
