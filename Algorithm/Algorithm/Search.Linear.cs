using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static partial class Search
	{
        public static int LinearSearch(List<int> list, int target)
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (list[i] == target)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}


