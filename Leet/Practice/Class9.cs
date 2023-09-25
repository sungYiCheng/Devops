using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public partial class Solution
    {

        public string DecodeString(string s)
        {
            var repeat = 0;
            var sb = new StringBuilder(s.Length);
            var st = new Stack<(int, int)>();
            List<char> chars = new List<char>();

            foreach (var c in s)
            {
                if (c == '[')
                {
                    st.Push((chars.Count, repeat));
                    repeat = 0;
                }
                else if (c == ']')
                {
                    (int count, int times) = st.Pop();

                    List<char> temp = chars.GetRange(count, chars.Count - count);

                    for (int i = 0 ; i < times;  i++)
                    {     
                        sb.Append(string.Join("", temp));
                    }
                }
                else if (char.IsDigit(c))
                {
                    repeat = 10 * repeat + (c - '0'); // char 轉 int
                }
                else
                {
                    chars.Add(c);
                }
            }

            if (chars.Count > 0)
            {
                sb.Append(string.Join("", chars));
            }

            return sb.ToString();
        }
    }
}
