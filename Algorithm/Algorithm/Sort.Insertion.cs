using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static partial class Sort
	{
        public static void InsertionSort(List<int> list)
        {
            int temp;
            for (int i = 1; i < list.Count; i++)
            {
                temp = list[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (list[j] > temp)
                    {
                        list[j + 1] = list[j];

                        if (j == 0)
                        {
                            list[0] = temp;
                            break;
                        }
                    }
                    else
                    {
                        list[j + 1] = temp;
                        break;
                    }
                }
            }
        }
    }
}


