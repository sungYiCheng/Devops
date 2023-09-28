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

215. Kth Largest Element in an Array
Solved
Medium
Topics
Companies
Given an integer array nums and an integer k, return the kth largest element in the array.

Note that it is the kth largest element in the sorted order, not the kth distinct element.

Can you solve it without sorting?

 

Example 1:

Input: nums = [3,2,1,5,6,4], k = 2
Output: 5
Example 2:

Input: nums = [3,2,3,1,2,4,5,5,6], k = 4
Output: 4
 

Constraints:

1 <= k <= nums.length <= 105
-104 <= nums[i] <= 104
		 * 
		*/

		public int FindKthLargest(int[] nums, int k)
		{
			//20001 size because each nums[i] is in range -10^4 to 10^4
			int[] numCount = new int[20001];
			for (int i = 0; i < nums.Length; i++)
			{
				//adding 10000 to all numbers
				//especially to make negetive number as positive, to avoid negetive index issue
				int idx = nums[i] + 10000;

				numCount[idx]++;
			}

			//find Kth largest element
			int kthLarge = 0;
			for (int i = numCount.Length - 1; i >= 0; i--)
			{
				if (numCount[i] == 0)
				{
					continue;
				}

				//reduce 'k' by found number's frequency (frequency will be 0 if number was not present in nums)
				k -= numCount[i];

				if (k <= 0)
				{
					kthLarge = i - 10000;
					break;
				}
			}

			return kthLarge;
		}
	}
}
