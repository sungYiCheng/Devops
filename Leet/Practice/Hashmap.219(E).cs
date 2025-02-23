﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /*
     * 
     *219. Contains Duplicate II
Solved
Easy
Topics
Companies
Given an integer array nums and an integer k, return true if there are two distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k.

 

Example 1:

Input: nums = [1,2,3,1], k = 3
Output: true
Example 2:

Input: nums = [1,0,1,1], k = 1
Output: true
Example 3:

Input: nums = [1,2,3,1,2,3], k = 2
Output: false
 

Constraints:

1 <= nums.length <= 105
-109 <= nums[i] <= 109
0 <= k <= 105 
     * 
     * 
     * 
     */


    public partial class Solution
    {
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            Dictionary<int, int> Dic = new Dictionary<int, int>();

            bool check = false;
            for (int i = 0; i < nums.Length; i++)
            {
                if (!Dic.ContainsKey(nums[i]))
                {
                    Dic.Add(nums[i], i);
                }
                else
                {
                    if (i - Dic[nums[i]] <= k)
                    {
                        check = true;
                        break;
                    }

                    Dic[nums[i]] = i;
                }
            }

            return check;
        }
    }
}
