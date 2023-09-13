using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static partial class Search
	{
        public static int BinarySearch(List<int> list, int target)
        {
            int low = 0;
            int high = list.Count - 1;
            list.Sort();

            while (low <= high)
            {
                int checkIndex = (low + high) / 2;

                if (list[checkIndex] == target)
                {
                    return checkIndex;
                }
                else if (list[checkIndex] > target)
                {
                    high = checkIndex - 1;
                }
                else if (list[checkIndex] < target)
                {
                    low = checkIndex + 1;
                }
            }

            return -1;
        }
    }
}


