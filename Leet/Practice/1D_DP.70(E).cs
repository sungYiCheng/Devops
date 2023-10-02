using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public partial class Solution
	{
		/*
		 * 
		 * 70. Climbing Stairs
Solved
Easy
Topics
Companies
Hint
You are climbing a staircase. It takes n steps to reach the top.

Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

 

Example 1:

Input: n = 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps
Example 2:

Input: n = 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step
 

Constraints:

1 <= n <= 45
		 * 
		 */

		public int ClimbStairs(int n)
		{
			List<int> list = new List<int> { 1, 2 };

			for (int i = 0; i < n; i++)
			{
				if (list.Count == i)
				{
					int step = list[i - 1] + list[i - 2];
					list.Add(step);
				}
			}

			return list[n - 1];
		}
	}
}
