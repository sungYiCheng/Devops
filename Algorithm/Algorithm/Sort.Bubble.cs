using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static partial class Sort
	{
        /*
         * 總共比較了 1+2+3+…+(n-1)
            也就是 n*(n-1)/2
            時間複雜度會忽略係數，所以為 

            O(n^2)
         * 
         * 
         * Steable  (相同的就不會換，所以穩定)
         * 
         */

        public static void BubbleSort(List<int> list)
        {
            // 因為最後排好的會是最大值，所以從最大值開始遞減，注意 第二回圈的  k < i，代表每次都會多排好一個最大值了
            for (int i = list.Count - 1; i >= 0; i--)
            {
                for (int k = 0; k < i; k++)
                {
                    if (list[k] > list[k + 1])
                    {
                        Swap(list, k, k + 1);
                    }
                }
            }
        }
    }
}


