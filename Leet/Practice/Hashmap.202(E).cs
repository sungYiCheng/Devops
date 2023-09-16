using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /*
     * 
     * 202. Happy Number
Solved
Easy
Topics
Companies
Write an algorithm to determine if a number n is happy.

A happy number is a number defined by the following process:

Starting with any positive integer, replace the number by the sum of the squares of its digits.
Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
Those numbers for which this process ends in 1 are happy.
Return true if n is a happy number, and false if not.

 

Example 1:

Input: n = 19
Output: true
Explanation:
1*1 + 9*9 = 82
8*8 + 2*2 = 68
6*6 + 8*8 = 100
1*1 + 0*0 + 0*0 = 1
Example 2:

Input: n = 2
Output: false
 

Constraints:

1 <= n <= 231 - 1
     * 
     */

    public partial class Solution
    {
        public bool IsHappy(int n)
        {
            List<int> list = new List<int>();
            int sum = 0, temp = 0;
            bool happy = false;

            while (true)
            {
                temp = n % 10;
                sum += temp * temp;

                if (temp == 0 && n == 0)
                {
                    if (sum == 1)
                    {
                        happy = true;
                        break;
                    }

                    // 預防無限輪迴，怎模拆解都會跑進來的情況
                    if (list.Contains(sum))
                    {
                        break;
                    }

                    list.Add(sum);

                    n = sum;
                    sum = 0;
                }
                else
                {
                    n = n / 10;
                }
            }

            return happy;
        }
    }
}
