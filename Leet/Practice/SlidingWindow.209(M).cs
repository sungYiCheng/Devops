using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	/*
	 * 
	 * 209. Minimum Size Subarray Sum
Solved
Medium
Topics
Companies
Given an array of positive integers nums and a positive integer target, return the minimal length of a 
subarray
 whose sum is greater than or equal to target. If there is no such subarray, return 0 instead.

 

Example 1:

Input: target = 7, nums = [2,3,1,2,4,3]
Output: 2
Explanation: The subarray [4,3] has the minimal length under the problem constraint.
Example 2:

Input: target = 4, nums = [1,4,4]
Output: 1
Example 3:

Input: target = 11, nums = [1,1,1,1,1,1,1,1]
Output: 0
 

Constraints:

1 <= target <= 109
1 <= nums.length <= 105
1 <= nums[i] <= 104
	 */


	public partial class Solution
	{

		public int MinSubArrayLen(int target, int[] nums)
		{
			int sum = 0;
			int minSize = int.MaxValue;
			List<int> list = new List<int>();

			foreach(int num in nums)
			{
				if (sum < target)
				{
					sum += num;
					list.Add(num);
				}

				while (sum >= target)
				{
					minSize = Math.Min(minSize, list.Count);

					sum -= list.First();
					list.RemoveAt(0);
				}
			}

			return minSize == int.MaxValue ? 0 : minSize;
		}







		public int MinSubArrayLen2(int target, int[] nums)
		{
			int sum = 0;
			int minSize = int.MaxValue;
			List<int> list = new List<int>();

			for (int i = 0; i < nums.Length; i++)
			{
				if (sum < target)
				{
					sum += nums[i];
					list.Add(nums[i]);
				}

				while (sum >= target)
				{
					minSize = Math.Min(minSize, list.Count);
					sum -= list.First();

					list.RemoveAt(0);
				}
			}

			return minSize == int.MaxValue ? 0 : minSize;
		}
	}
}
