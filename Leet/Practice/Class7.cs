using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public partial class Solution
    {
        public string RemoveStars(string s)
        {
            char[] chars = s.ToCharArray();
            Stack<char> stack = new Stack<char>();
            char star = '*';

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] != star)
                {
                    stack.Push(chars[i]);
                }
                else
                {
                    stack.Pop();
                }
            }

            StringBuilder stringBuilder = new StringBuilder();
            while (stack.Count > 0)
            {
                stringBuilder.Insert(0,stack.Pop());
            }

            return stringBuilder.ToString();
        }
    }
}
