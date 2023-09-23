using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	/*
	 * 169. Majority Element
Solved
Easy
Topics
Companies
Given an array nums of size n, return the majority element.

The majority element is the element that appears more than ⌊n / 2⌋ times. You may assume that the majority element always exists in the array.

 
Example 1:

Input: nums = [3,2,3]
Output: 3


Example 2:

Input: nums = [2,2,1,1,1,2,2]
Output: 2
 

Constraints:

n == nums.length
1 <= n <= 5 * 104
-109 <= nums[i] <= 109
	 * 
	 * 
	 */


	public partial class Solution
	{
		public int MajorityElement(int[] nums)
		{
			int length = nums.Length;
			Dictionary<int, int> dic = new Dictionary<int, int>();

			for (int i = 0; i < length; i++)
			{
				if (!dic.ContainsKey(nums[i]))
				{
					dic.Add(nums[i], 1);
				}
				else
				{
					dic[nums[i]]++;
				}
			}

			int maxKey = 0;
			int maxValue = 0;
			foreach (KeyValuePair<int, int> pair in dic)
			{
				if (pair.Value > maxValue)
				{
					maxKey = pair.Key;
					maxValue = pair.Value;
				}
			}

			return maxKey;
		}
	}
}
