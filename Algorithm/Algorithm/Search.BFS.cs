using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static partial class Search
	{
        public static bool BFSSearch(Dictionary<int, List<int>> graph, int target)
        {
            HashSet<int> visited  = new HashSet<int>();
            Queue<int> queue = new Queue<int>();

            // 假設從 node 1 開始搜尋
            queue.Enqueue(1);

            if (target == 1)
			{
                return true;
			}

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                Console.WriteLine($"Visit Node: {node}");

                if (target == node)
                {
                    Console.WriteLine($"Find it!");
                    return true;
                }

                if (visited .Contains(node))
				{
                    continue;
                }
                else
				{
                    visited.Add(node);
                }

                graph.TryGetValue(node, out List<int> neighbours);

                if (neighbours == null)
				{
                    Console.WriteLine($"No Neighbours");
                    Console.WriteLine($"now queue: {string.Join(", ", queue.ToArray())}");
                    Console.WriteLine("\n");
                    continue;
                }

                Console.WriteLine($"Neighbours: {string.Join(",", neighbours)}");

                foreach (var item in neighbours)
                {
                    queue.Enqueue(item);
                    Console.WriteLine($"put: {item} in queue, now queue: {string.Join(", ", queue.ToArray())}");
                }

                Console.WriteLine("\n");
            }

            return false;
        }
    }
}


