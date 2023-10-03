using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public partial class Solution
    {

        public long getTime(string s)
        {
            char[] array = s.ToCharArray();
    
            int ANum = Convert.ToInt32('A');
            int prev = ANum;
            int prevIndex = 26;
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == prev)
                {
                    continue;
                }

                int temp = Convert.ToInt32(array[i]);
                int sub = temp - ANum;
                int LIndex = 0 + sub;
                int MIndex = 26 + sub;
                int RIndex = 52 + sub;

                int min = Math.Min(prevIndex - LIndex, Math.Abs(prevIndex - MIndex));
                min = Math.Min(min, Math.Abs(RIndex - prevIndex));

                sum += min;

                prev = temp;
                prevIndex = MIndex;
            }

            return sum;
        }
    }

}
