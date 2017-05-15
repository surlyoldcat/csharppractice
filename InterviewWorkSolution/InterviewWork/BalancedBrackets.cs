using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewWork
{
    public class BalancedBrackets
    {
        public static bool IsBalanced(string input)
        {
            char[] openBracketChars = { '{', '[', '(' };
            if (String.IsNullOrEmpty(input))
            {
                return false;
            }

            var inputChars = input.ToArray();

            Stack<char> openBrackets = new Stack<char>(inputChars.Length);

            for (int i = 0; i < inputChars.Length; i++)
            {
                char c = inputChars[i];
                if (openBracketChars.Contains(c))
                {
                    openBrackets.Push(c);
                }
                else
                {
                    //it's a closing bracket- it must match the most
                    //recent opening bracket
                    if (openBrackets.Count < 1)
                    {
                        return false;
                    }
                    char opener = openBrackets.Pop();
                    if (!IsBracketPair(opener, c))
                    {
                        return false;
                    }
                }

            }

            return openBrackets.Count == 0;

        }

        private static bool IsBracketPair(char opener, char closer)
        {
            if (opener == '{')
            {
                return closer == '}';
            }
            if (opener == '[')
            {
                return closer == ']';
            }
            if (opener == '(')
            {
                return closer == ')';
            }
            return false;
        }

        
    }
}
