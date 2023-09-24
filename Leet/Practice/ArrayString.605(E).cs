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
        /*
         * 605. Can Place Flowers
Solved
Easy
Topics
Companies
You have a long flowerbed in which some of the plots are planted, and some are not. However, flowers cannot be planted in adjacent plots.

Given an integer array flowerbed containing 0's and 1's, where 0 means empty and 1 means not empty, and an integer n, return true if n new flowers can be planted in the flowerbed without violating the no-adjacent-flowers rule and false otherwise.

 

Example 1:

Input: flowerbed = [1,0,0,0,1], n = 1
Output: true
Example 2:

Input: flowerbed = [1,0,0,0,1], n = 2
Output: false
 

Constraints:

1 <= flowerbed.length <= 2 * 104
flowerbed[i] is 0 or 1.
There are no two adjacent flowers in flowerbed.
0 <= n <= flowerbed.length
         * 
         * 
         */

        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            Stack<int> flowerStack = new Stack<int>();
          
            int count = 0;
            for (int i = 0; i < flowerbed.Length; i++)
            {
                flowerStack.Push(flowerbed[i]);

                if (flowerbed[i] == 0)
                {
                    count++;

                    //  3個0 或是 開頭兩個0
                    if (count >= 3 || (count == 2 && flowerStack.Count == 2))
                    {
                        flowerStack.Pop();
                        flowerStack.Pop();
                        flowerStack.Push(1);
                        flowerStack.Push(0);

                        n--;
                        count = 1;
                    }
                    else if (count == 2 && flowerStack.Count == flowerbed.Length)  // 結尾兩個0
                    {
                        flowerStack.Pop();
                        flowerStack.Pop();
                        flowerStack.Push(0);
                        flowerStack.Push(1);

                        n--;
                    }
                }
                else
                {
                    count = 0;
                }

                if (n <= 0)
                {
                    return true;
                }
            }

            // 只有一個 0 也OK
            return (flowerStack.Count == 1 && count == 1) ? true : false;
        }
    }
}
