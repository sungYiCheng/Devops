using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /*
     * 
Code

Testcase
Testcase
Result

209. Minimum Size Subarray Sum
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

            for (int i = 0; i < nums.Length; i++)
            {
                // 依序累加上去，每家一個，就往下while檢查
                if (sum < target)
                {
                    sum += nums[i];
                    list.Add(nums[i]);
                }

                //  從list前面開始扣，目的為看新加入的能扣除多少為最少>=target的情況 (可能扣到最後只剩新加入的一個，代表新加入的 = target，即可找出最短list)
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
