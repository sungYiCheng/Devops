using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static partial class Sort
	{
        public static void QuickSort(List<int> list)
        {
            QuickSortAction(list, 0, list.Count - 1);
        }

        public static void QuickSortAction(List<int> list, int low, int high)
        {
            if (low >= high)
			{
                return;
            }

            int temp = list[low];
            int i = low + 1;
            int j = high;

            while (true)
            {
                // 從後方找 比 目標小的
                while (list[j] > temp)
                {
                    j--;
                }

                // 從前方找 比 目標大的
                while (list[i] < temp && i < j)
				{
                    i++;
                }

                if (i >= j)
				{
                    break;
                }

                Swap(list, i, j);
                i++; 
                j--;
            }

            if (j != low)
			{
                Swap(list, low, j);
            }

            QuickSortAction(list, j + 1, high);
            QuickSortAction(list, low, j - 1);
        }
    }
}


