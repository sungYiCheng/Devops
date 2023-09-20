using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static partial class Search
	{
        /*
         * 
         * O(n)
         * 
         */

        public static int InterpolationSearch(List<int> list, int target)
        {
            int low = 0;
            int high = list.Count - 1;
            list.Sort();

            while (low <= high)
            {
                // 腳色 x = checkIndex,  target = y, low = x1, high = x2, list[low] = y1, list[high] = y2
                // y-y1 / x-x1 = y2 - y1 / x2 - x1 整理過後, x = (y - y1) * (x2 - x1) / y2 - y1 + x1
                // target - list[low] / checkIndex - low =  list[high] - list[low] / high - low，整理過後 如下

                int checkIndex = (target - list[low]) * (high - low) / (list[high] - list[low]) + low;

                if (checkIndex > high || checkIndex < low)
                {
                    break;
                }

                if (target == list[checkIndex])
                {
                    return checkIndex;
                }
                else if (target > list[checkIndex])
                {
                    low = checkIndex + 1;
                }
                else
                {
                    high = checkIndex - 1;
                }
            }

            return -1;
        }
    }
}


