using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public partial class Solution
    {
        public int MaxVowels(string s, int k)
        {
            List<char> vowels = new List<char>() {'a', 'e', 'i', 'o', 'u' };
            char[] chars = s.ToCharArray();
            List<char> list = new List<char>();

            int max = int.MinValue;
            int count = 0;
            for (int i = 0; i < chars.Length; i++) 
            {
                int step = 0;
                list.Add(chars[i]);

                for (int j = list.Count - 1; j >= 0; i--)
                {
                    step++;
                    char check = list[j];

                    if (vowels.Contains(check))
                    {
                        count++;
                    }

                    if (step >= k)
                    {
                        break;
                    }
                }

                max = Math.Max(max, count);
            }

            return max;
        }
    }
}
