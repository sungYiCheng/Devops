using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
   

    public static partial class Sort
	{
        /*
         * 
        * 總共比較了 1+2+3+…+(n-1)
          也就是 n*(n-1)/2
          時間複雜度會忽略係數，所以為 

          O(n^2)
        * 
        * 
        * Unsteable (每一輪交換，可能會把 相同的前面數 丟到後面去 ex: 5 8 5 2 9 ， 第一次 5和2交換後，前面的5就被丟到後面去了)
        * 
        * 
        */

        public static void SelectSort(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                // 每一輪的初始最小值和index
                int min = i;
                int check = list[i];

                // 開始往上比較，找出往上中的最小值
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < check)
                    {
                        min = j;
                        check = list[j];
                    }
                }

                // 經過一輪找之後，只要min不等於一開始初始的 i (代表比較完後，i 就是這輪最小，不用交換)，把找到新的最小值和i交換
                if (min != i)
				{
                    Swap(list, min, i);
                }
            }
        }
    }
}


