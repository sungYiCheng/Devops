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
		35. Search Insert Position
Easy

Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.

You must write an algorithm with O(log n) runtime complexity.

 

Example 1:
Input: nums = [1,3,5,6], target = 5
Output: 2

Example 2:
Input: nums = [1,3,5,6], target = 2
Output: 1

Example 3:
Input: nums = [1,3,5,6], target = 7
Output: 4
 

Constraints:

1 <= nums.length <= 104
-104 <= nums[i] <= 104
nums contains distinct values sorted in ascending order.
-104 <= target <= 104


		*/

		public int SearchInsert(int[] nums, int target)
		{
			return Find(ref nums, ref target, 0, nums.Length - 1);
		}

		public int Find(ref int[] nums, ref int target, int startIndex, int endIndex)
		{
			int getIndex = (endIndex - startIndex) / 2;

			if (getIndex > 0)
			{
				int checkIndex = startIndex + getIndex;

				if (target == nums[checkIndex])
				{
					return checkIndex;
				}
				else if (target > nums[checkIndex])
				{
					return Find(ref nums, ref target, checkIndex, endIndex);
				}
				else
				{
					return Find(ref nums, ref target, startIndex, checkIndex);
				}
			}
			else 
			{
				if (target == nums[endIndex])
				{
					return endIndex;
				}
				else if (target <= nums[startIndex])
				{ 
					return startIndex;
				}
				else if (target > nums[endIndex])
				{
					return endIndex + 1;
				}
				else
				{
					return startIndex + 1;
				}
			}
		}
	}
}
