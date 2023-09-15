using System;

namespace Practice
{
	class Program
	{
		static void Main(string[] args)
		{
			Solution solution = new Solution();

			string path = "/home/";
			path = "/../";
			path = "/a/./b/../../c/";
			string ans = solution.SimplifyPath(path);
		}
	}
}
