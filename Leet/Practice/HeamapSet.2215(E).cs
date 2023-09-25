using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /*
	 * 2215. Find the Difference of Two Arrays
Solved
Easy
Topics
Companies
Hint
Given two 0-indexed integer arrays nums1 and nums2, return a list answer of size 2 where:

answer[0] is a list of all distinct integers in nums1 which are not present in nums2.
answer[1] is a list of all distinct integers in nums2 which are not present in nums1.
Note that the integers in the lists may be returned in any order.

 

Example 1:

Input: nums1 = [1,2,3], nums2 = [2,4,6]
Output: [[1,3],[4,6]]
Explanation:
For nums1, nums1[1] = 2 is present at index 0 of nums2, whereas nums1[0] = 1 and nums1[2] = 3 are not present in nums2. Therefore, answer[0] = [1,3].
For nums2, nums2[0] = 2 is present at index 1 of nums1, whereas nums2[1] = 4 and nums2[2] = 6 are not present in nums2. Therefore, answer[1] = [4,6].
Example 2:

Input: nums1 = [1,2,3,3], nums2 = [1,1,2,2]
Output: [[3],[]]
Explanation:
For nums1, nums1[2] and nums1[3] are not present in nums2. Since nums1[2] == nums1[3], their value is only included once and answer[0] = [3].
Every integer in nums2 is present in nums1. Therefore, answer[1] = [].
 

Constraints:

1 <= nums1.length, nums2.length <= 1000
-1000 <= nums1[i], nums2[i] <= 1000
	 * 
	 * 
	 */

    public partial class Solution
    {
        public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
		{
            IList<IList<int>> final = new List<IList<int>>();
            List<int> num1List = nums1.ToList();
            List<int> num2List = nums2.ToList();

            List<int> excpt_1 = num1List.Except(num2List).ToList();
            List<int> excpt_2 = num2List.Except(num1List).ToList();

            final.Add(excpt_1);
            final.Add(excpt_2);

            return final;
        }

        public IList<IList<int>> FindDifference_V2(int[] nums1, int[] nums2)
        {
            IList<IList<int>> final = new List<IList<int>>();
            List<int> num1List = nums1.ToList();
            List<int> num2List = nums2.ToList();

            List<int> ans1 = new List<int>();
            for (int i = 0; i < num1List.Count; i++)
            {
                if (!num2List.Contains(num1List[i]))
                {
                    if (!ans1.Contains(num1List[i]))
                    {
                        ans1.Add(num1List[i]);
                    }
                }
            }
            final.Add(ans1);

            List<int> ans2 = new List<int>();
            for (int i = 0; i < num2List.Count; i++)
            {
                if (!num1List.Contains(num2List[i]))
                {
                    if (!ans2.Contains(num2List[i]))
                    {
                        ans2.Add(num2List[i]);
                    }
                }
            }

            final.Add(ans2);

            return final;
        }
    }
}
