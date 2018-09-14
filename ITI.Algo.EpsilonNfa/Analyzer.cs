using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Algo.RegularExpression
{
    public class Analyzer
    {
        public Analyzer(string text) => AnalyzeToTokenize(text);

        public void AnalyzeToTokenize(string text)
        {
            Tokenizer t = new Tokenizer(text);
            foreach (TokenType token in t.tokenTypes)
            {
                ParsePipe(token);
            }
        }

        public static Node ParsePipe(TokenType tokenType)
        {
            TokenType parseChar = ParseChar(tokenType);
            if (parseChar == TokenType.Pipe)
            {
                Node node = ParseExpression();
            }
        }

        public static void ParseKleene(TokenType type)
        {
            throw new NotImplementedException();
        }

        public static TokenType ParseChar(TokenType tokenType)
        {
            throw new NotImplementedException();
        }

        public static Node ParseExpression()
        {
            throw new NotImplementedException();
        }
    }
}
