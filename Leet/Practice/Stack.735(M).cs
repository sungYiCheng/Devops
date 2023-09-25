using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public partial class Solution
    {
        /*
         * 735. Asteroid Collision
Solved
Medium
Topics
Companies
Hint
We are given an array asteroids of integers representing asteroids in a row.

For each asteroid, the absolute value represents its size, and the sign represents its direction (positive meaning right, negative meaning left). Each asteroid moves at the same speed.

Find out the state of the asteroids after all collisions. If two asteroids meet, the smaller one will explode. If both are the same size, both will explode. Two asteroids moving in the same direction will never meet.

 

Example 1:

Input: asteroids = [5,10,-5]
Output: [5,10]
Explanation: The 10 and -5 collide resulting in 10. The 5 and 10 never collide.
Example 2:

Input: asteroids = [8,-8]
Output: []
Explanation: The 8 and -8 collide exploding each other.
Example 3:

Input: asteroids = [10,2,-5]
Output: [10]
Explanation: The 2 and -5 collide resulting in -5. The 10 and -5 collide resulting in 10.
 

Constraints:

2 <= asteroids.length <= 104
-1000 <= asteroids[i] <= 1000
asteroids[i] != 0
         * 
         * 
         * 
         */



        public int[] AsteroidCollision(int[] asteroids)
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] > 0)
                {
                    stack.Push(asteroids[i]);
                }
                else
                {
                    if (stack.Count == 0 || stack.Peek() < 0)
                    {
                        stack.Push(asteroids[i]);
                    }
                    else
                    {
                        // 重點是 先看看stack頂端的情況，再決定要不要POP出來
                        while (stack.Count > 0 && stack.Peek() > 0)
                        {
                            int preNum = stack.Peek();
                            int absNow = Math.Abs(asteroids[i]);

                            if (preNum == absNow)  // 大小相同時，兩個都消失
                            {
                                stack.Pop();
                                break;
                            }

                            // 目前的負數夠大，會消滅掉Stack Top的正數，所以POP出一份
                            if (absNow - preNum > 0)
                            {
                                stack.Pop();

                                // 假設 Stack空了，或是top是負的，代表沒有正數可以抵抗了，把新的負數加入後離開迴圈檢查
                                if (stack.Count == 0 || stack.Peek() < 0)
                                {
                                    stack.Push(asteroids[i]);
                                    break;
                                }
                            }
                            else
                            {
                                // 代表 目前 Top 的正數贏了，直接消滅目前的負數，然後也不用POP出來，更不用把目前的負數加進去，可離開迴圈檢查
                                break;
                            }
                        }
                    }
                }
            }

            List<int> list = new List<int>();
            while (stack.Count > 0)
            {
                list.Insert(0, stack.Pop());
            }


            return list.ToArray();
        }
    }
}
