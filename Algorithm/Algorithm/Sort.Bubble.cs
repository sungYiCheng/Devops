using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static partial class Sort
	{
        public static void BubbleSort(List<int> list)
        {
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


