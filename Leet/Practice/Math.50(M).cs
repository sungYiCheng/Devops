using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /*
	 * 
	 * 50. Pow(x, n)
Solved
Medium
Topics
Companies
Implement pow(x, n), which calculates x raised to the power n (i.e., xn).

 

Example 1:

Input: x = 2.00000, n = 10
Output: 1024.00000
Example 2:

Input: x = 2.10000, n = 3
Output: 9.26100
Example 3:

Input: x = 2.00000, n = -2
Output: 0.25000
Explanation: 2-2 = 1/22 = 1/4 = 0.25
 

Constraints:

-100.0 < x < 100.0
-231 <= n <= 231-1
n is an integer.
Either x is not zero or n > 0.
-104 <= xn <= 104
	 * 
	 */


    public partial class Solution
    {
        public double MyPow(double x, int n)
        {
            // 不太懂為何
            // handle special case when n is equal to Int32.MinValue
            if (n == int.MinValue)
            {
                n = -(n + 1);
                x = 1.0 / x;
                return x * x * MyPow(x * x, n / 2);
            }

            if (n == 0)
            {
                return 1.0;
            }
            else if (n < 0)
            {
                x = 1.0 / x;
                n = -n;
            }

            if (n % 2 == 0)
            {
                double y = MyPow(x, n / 2);
                return y * y;
            }
            else
            {
                double y = MyPow(x, (n - 1) / 2);
                return y * y * x;
            }
        }
    }
}
