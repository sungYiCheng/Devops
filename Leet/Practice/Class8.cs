using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public partial class Solution
    {
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
