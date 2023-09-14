using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static partial class Search
	{
        public static bool DFSSearch(Dictionary<int, List<int>> tree, int target)
        {
            HashSet<int> visited  = new HashSet<int>();
            Stack<int> stack = new Stack<int>();

            // 假設從 node 1 開始搜尋
            stack.Push(1);

            if (target == 1)
			{
                return true;
			}

            while (stack.Count > 0)
            {
                var node = stack.Pop();

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

                tree.TryGetValue(node, out List<int> neighbours);

                if (neighbours == null)
				{
                    Console.WriteLine($"No Neighbours");
                    Console.WriteLine($"now stack: {string.Join(", ", stack.ToArray())}");
                    Console.WriteLine("\n");
                    continue;
                }

                Console.WriteLine($"Neighbours: {string.Join(",", neighbours)}");

                foreach (var item in neighbours)
                {
                    stack.Push(item);
                    Console.WriteLine($"put: {item} in stack, now stack {string.Join(", ", stack.ToArray())}");
                }

                Console.WriteLine("\n");
            }

            return false;
        }
    }
}


