using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	/*
	 * 
	 * 172. Factorial Trailing Zeroes
Solved
Medium
Topics
Companies
Given an integer n, return the number of trailing zeroes in n!.

Note that n! = n * (n - 1) * (n - 2) * ... * 3 * 2 * 1.

 

Example 1:

Input: n = 3
Output: 0
Explanation: 3! = 6, no trailing zero.
Example 2:

Input: n = 5
Output: 1
Explanation: 5! = 120, one trailing zero.
Example 3:

Input: n = 0
Output: 0
 

Constraints:

0 <= n <= 104
	 * 
	 * 
	 */
	public partial class Solution
	{
		public int TrailingZeroes(int n)
		{
			int count = 0;
			int fiveCount = int.MaxValue;
			while (fiveCount > 0)
			{
				fiveCount = n / 5;
				count += fiveCount;
				n = fiveCount;
			}


			return count;
		}
	}
}
