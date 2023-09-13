using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static partial class Sort
	{
        public static void SelectSort(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                int min = i;
                int temp = list[i];
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < temp)
                    {
                        min = j;
                        temp = list[j];
                    }
                }

                if (min != i)
				{
                    Swap(list, min, i);
                }
            }
        }
    }
}


