using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Algo.RegularExpression
{
    public class Tokenizer
    {
        string _input;
        public HashSet<TokenType> tokenTypes = new HashSet<TokenType>();
        public HashSet<string> strings = new HashSet<string>();

        public Tokenizer(string input)
        {
            _input = input;
            StringToHashSetToken(input);
        }

        public void StringToHashSetToken(string input)
        {
            for (int x = 0; x < input.Length; x++)
            {
                switch (input[x])
                {
                    case '(':
                        tokenTypes.Add(TokenType.OpenBracket);
                        break;
                    case ')':
                        tokenTypes.Add(TokenType.CloseBracket);
                        break;
                    case '|':
                        tokenTypes.Add(TokenType.Pipe);
                        break;
                    case '*':
                        tokenTypes.Add(TokenType.Kleene);
                        break;
                }

                StringBuilder sb = new StringBuilder();
                sb.Clear();

                if (char.IsLetter(input[x]))
                {
                    if (!char.IsLetter(input[x + 1])) sb.Append(input[x]);
                    
                    while (x < input.Length && char.IsLetter(input[x]))
                    {
                        sb.Append(input[x]);
                        x++;
                    }

                    strings.Add(sb.ToString());
                    tokenTypes.Add(TokenType.Char);
                }
            }
        }
    }
}
