using System;

namespace Practice
{
	class Program
	{
		static void Main(string[] args)
		{
			Solution solution = new Solution();

			var ans = solution.LongestCommonPrefix(new string[] {"flow", "flower", "flight"  });

			Console.WriteLine($"ans:{ans}");
		}
	}
}
