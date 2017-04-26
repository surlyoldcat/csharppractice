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
            if (String.IsNullOrEmpty(input))
            {
                return false;
            }

            var inputChars = input.ToArray();
            Stack<char> openBrackets = new Stack<char>(inputChars.Length);

            for (int i = 0; i < inputChars.Length; i++)
            {
                char c = inputChars[i];
                if (IsOpenBracket(c))
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
            return true;

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

        private static bool IsOpenBracket(char c)
        {
            switch(c)
            {
                case '[':
                case '{':
                case '(':
                    return true;
                default:
                    return false;
            }
        }

        private static string PrintStack(Stack<char> stk)
        {
            string s = "";
            foreach(var val in stk)
            {
                s += val + Environment.NewLine;
            }
            return s;
        }
    }
}
