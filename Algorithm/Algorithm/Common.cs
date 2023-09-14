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

        private static void Swap(List<int> list, int i, int j)
		{
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    public static partial class Search
	{
        public static void Show(Dictionary<int, List<int>> tree)
        {
            foreach (KeyValuePair<int, List<int>> pair in tree)
			{
                Console.Write($"Tree node:{pair.Key}, neighbours: {String.Join(", ", pair.Value)}");
                Console.Write("\n");
            }

            Console.Write("\n");
        }

        public static void Show(int target, int index)
        {
            Console.Write("\n");
            Console.Write($"Search Targe:{target}, find index: {index}");
        }

        public static void Show(int target, bool find)
        {
            Console.Write("\n");
            Console.Write($"Search Targe:{target}, find: {find}");
        }
    }
}


