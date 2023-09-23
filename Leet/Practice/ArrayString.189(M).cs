using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	/*
	 * 189. Rotate Array
Solved
Medium
Topics
Companies
Hint
Given an integer array nums, rotate the array to the right by k steps, where k is non-negative.

 

Example 1:

Input: nums = [1,2,3,4,5,6,7], k = 3
Output: [5,6,7,1,2,3,4]
Explanation:
rotate 1 steps to the right: [7,1,2,3,4,5,6]
rotate 2 steps to the right: [6,7,1,2,3,4,5]
rotate 3 steps to the right: [5,6,7,1,2,3,4]
Example 2:

Input: nums = [-1,-100,3,99], k = 2
Output: [3,99,-1,-100]
Explanation: 
rotate 1 steps to the right: [99,-1,-100,3]
rotate 2 steps to the right: [3,99,-1,-100]
 

Constraints:

1 <= nums.length <= 105
-231 <= nums[i] <= 231 - 1
0 <= k <= 105
	 * 
	 * 
	 * 
	 */

	public partial class Solution
	{
		public void Rotate(int[] nums, int k)
		{
			int length = nums.Length;
			int finalK = k % length;

			List<int> list = new List<int>();
			for (int i = length - finalK; i < length; i++)
			{
				list.Add(nums[i]);
			}

			for (int i = 0; i < length - finalK; i++)
			{
				list.Add(nums[i]);
			}

			for (int i = 0; i < length; i++)
			{
				nums[i] = list[i];
			}
		}


		public void Rotate_V2(int[] nums, int k)
		{
			List<int> numList = nums.ToList();

			int rotateK = k % nums.Length;

			List<int> newNums = numList.GetRange(0, nums.Length - rotateK);
			List<int> rotate = numList.GetRange(nums.Length - rotateK, rotateK);
			rotate.Reverse();

			foreach (int num in rotate)
			{
				newNums.Insert(0, num);
			}

			for (int i = 0; i < newNums.Count; i++)
			{
				nums[i] = newNums[i];
			}
		}




	}
}
