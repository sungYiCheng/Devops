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

<<<<<<< HEAD
            //var ans = solution.getTime("AZGB");
            var ans = solution.getTime("BGZXC");
=======
			var ans = solution.Test2(source);
>>>>>>> e499d62cbd9a58a9be7c2ca8ff44f07048e1f7a9

            Console.WriteLine($"ans:{ans}");
		}

	}
}
