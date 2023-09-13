using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static partial class Search
	{
        public static int BFSSearch(List<int> list, int target)
        {
            Dictionary<int, List<int>> tree = new Dictionary<int, List<int>>();
            tree.Add(1, new List<int> { 2, 3, 4 });
            tree.Add(2, new List<int> { 5 });
            tree.Add(3, new List<int> { 6, 7 });
            tree.Add(4, new List<int> { 8});
            tree.Add(5, new List<int> { 9 });
            tree.Add(6, new List<int> { 10 });


            HashSet<int> itemCovered = new HashSet<int>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(tree.ElementAt(0).Key);

            while (queue.Count > 0)
            {
                var element = queue.Dequeue();
                if (itemCovered.Contains(Convert.ToInt32(element)))
                    continue;
                else
                    itemCovered.Add(Convert.ToInt32(element));
                Console.WriteLine(element);
                List neighbours;
                tree.TryGetValue(Convert.ToInt32(element), out neighbours);
                if (neighbours == null)
                    continue;
                foreach (var item1 in neighbours)
                {
                    queue.Enqueue(item1);
                }
            }

            return -1;
        }
    }
}


