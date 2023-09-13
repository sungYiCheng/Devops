using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static partial class Sort
	{
        public static void Show(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
        }

        public static void Show(int target, int index)
        {
            Console.Write("\n");
            Console.Write($"Search Targe:{target}, find index: {index}");
        }

        private static void Swap(List<int> list, int i, int j)
		{
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}


