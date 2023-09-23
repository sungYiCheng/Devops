using System;
using System.Collections.Generic;

namespace Practice
{
	class Program
	{
		static void Main(string[] args)
		{
			Solution solution = new Solution();

			List<List<int>> list = new List<List<int>>();
			list.Add(new List<int> { 4 });
			list.Add(new List<int> { -1, 1, -7, -8 });
			list.Add(new List<int> { -10, -8, -5, -2 });
			list.Add(new List<int> { 0, 9, 7, -1 });
			list.Add(new List<int> { 4, 4, -2, 1 });

			var ans = solution.MinSubArrayLen(7, new int[] { 2, 3, 1, 2, 4, 3 });

			Console.WriteLine($"ans:{ans}");
		}

	}
}
