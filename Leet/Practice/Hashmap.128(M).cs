using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /*
     * 128. Longest Consecutive Sequence
Solved
Medium
Topics
Companies
Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.

You must write an algorithm that runs in O(n) time.

 

Example 1:

Input: nums = [100,4,200,1,3,2]
Output: 4
Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.
Example 2:

Input: nums = [0,3,7,2,5,8,4,6,0,1]
Output: 9
 

Constraints:

0 <= nums.length <= 105
-109 <= nums[i] <= 109
     * 
     * 
     */


    public partial class Solution
    {
        public int LongestConsecutive(int[] nums)
        {
            Array.Sort(nums);

            int max = int.MinValue;
            int count = 0;
            int prev = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == prev)
                {
                    continue;
                }

                if ((prev == int.MinValue) || ((nums[i] - prev) == 1))
                {
                    count++;
                    max = Math.Max(max, count);
                }
                else
                {
                    count = 1;
                }

                prev = nums[i];
            }

            return max == int.MinValue ? 0 : max;
        }
    }
}
