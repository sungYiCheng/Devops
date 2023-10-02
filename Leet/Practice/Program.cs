using System;
using System.Collections.Generic;

namespace Practice
{
	class Program
	{
		static void Main(string[] args)
		{
			Solution solution = new Solution();

			int[][] array = new int[2][];
			array[0] = new int[2] { 3, 3};
            array[1] = new int[2] { 3, 3};
			//array[2] = new int[3] { 2, 7, 7 };

			List<List<string>> source = new List<List<string>>();
			source.Add(new List<string> { "a", "a", "a", "b", "a" });
			source.Add(new List<string> { "a", "b", "a", "b", "a" });
			source.Add(new List<string> { "a", "a", "a", "b", "c" });

			var ans = solution.Test2(source);

			Console.WriteLine($"ans:{ans}");
		}

	}
}
