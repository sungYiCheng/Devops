using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public partial class Solution
    {
        public long strangeCounter(long t)
        {
            long left = t;
            int index = 1;
            for (int i = 0; i < t; i++)
            {
                long pow = Convert.ToInt64(Math.Pow(2, i));
                long temp = left - Convert.ToInt64((3 * pow));

                if (temp > 0)
				{
                    left = temp;
                }
                else
                {
                    index = i + 1;
                    break;
                }
            }

            long ans = Convert.ToInt64(3 * Convert.ToInt64(Math.Pow(2, index - 1)));

            ans -= (left - 1);

            return ans;
        }


    }
}
