using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static partial class Search
	{
        /*
         * 先用 2^n 慢慢找到 範圍 (假設找到  落在 index為 2^3~ 2^4 內)
         * 
         * 再用 二元搜尋
         * 
         * 
         * O(log n) 
         * 
         */


        public static int ExponentialSearch(List<int> list, int target)
        {
            int low = 0;
            int high = list.Count - 1;
            list.Sort();

            for(double i = 0; i < list.Count; i++)
			{
                int checkIndex = Convert.ToInt32(Math.Pow(2, i));

                if (checkIndex > high)
				{
                    break;
				}

                if (list[checkIndex] == target)
				{
                    return checkIndex;
                }
                else if (list[checkIndex] < target)
				{
                    low = checkIndex;
                }
                else
				{
                    high = checkIndex;
                }
			}

            List<int> seatchList = list.GetRange(low, high - low);

            int index = Search.BinarySearch(seatchList, target);

            return index == -1 ? -1 : index + low;  // 找到的話，要加上low，因為二元搜尋的起點 Index 是 low
        }
    }
}


