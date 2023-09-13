using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    public static partial class Sort
	{
        public static List<int> MergeSort(List<int> list)
        {
            return SortAction(list);
        }

        private static List<int> SortAction(List<int> list)
        {
            if (list.Count < 2)
			{
                return list;
            }

            List<int> left = list.GetRange(0, list.Count / 2);
            List<int> right = list.GetRange(list.Count / 2, list.Count - list.Count / 2);

            return Merge(SortAction(left), SortAction(right));
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>(left.Count + right.Count);

            result.AddRange(left);
            result.AddRange(right);
            result.Sort();

            return result;
        }
    }
}


