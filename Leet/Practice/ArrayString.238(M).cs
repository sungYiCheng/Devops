using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /*
	 * 
	 * 238. Product of Array Except Self
Solved
Medium
Topics
Companies
Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].

The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

You must write an algorithm that runs in O(n) time and without using the division operation.

 

Example 1:

Input: nums = [1,2,3,4]
Output: [24,12,8,6]
Example 2:

Input: nums = [-1,1,0,-3,3]
Output: [0,0,9,0,0]
 

Constraints:

2 <= nums.length <= 105
-30 <= nums[i] <= 30
The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
 

Follow up: Can you solve the problem in O(1) extra space complexity? (The output array does not count as extra space for space complexity analysis.)
	 * 
	 * 
	*/

    public partial class Solution
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            int zeroCount = 0;
            int sum = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    sum *= nums[i];
                }
                else
                {
                    zeroCount++;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (zeroCount >= 2)  //  超過兩個以上的0 , 扣除自己就算是是 0 ，乘完也一定還是為0
                {
                    nums[i] = 0;
                }
                else if (zeroCount == 1)   // 只有一個 0, 除了為0以外的都是0，0的為其餘全部相乘
                {
                    nums[i] = (nums[i] != 0) ? 0 : sum;
                }
                else
                {
                    nums[i] = sum / nums[i];   //  都沒有0 , 就用 全部相乘 / 自己 即可
                }
            }
            return nums;
        }
    }
}
