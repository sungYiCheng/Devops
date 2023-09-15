using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	/*
	 * 56. Merge Intervals
Solved
Medium
Topics
Companies
Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.

 

Example 1:

Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
Output: [[1,6],[8,10],[15,18]]
Explanation: Since intervals [1,3] and [2,6] overlap, merge them into [1,6].
Example 2:

Input: intervals = [[1,4],[4,5]]
Output: [[1,5]]
Explanation: Intervals [1,4] and [4,5] are considered overlapping.
 

Constraints:

1 <= intervals.length <= 104
intervals[i].length == 2
0 <= starti <= endi <= 104
	 */

	public partial class Solution
	{
		public int[][] Merge(int[][] intervals)
		{
			Array.Sort(intervals, (a, b) => { return a[0] - b[0]; });  // 用每個 int[0] 來排序

			int start = int.MinValue;
			int end = int.MinValue;

			List<int[]> ans = new List<int[]>();
			for (int i = 0; i < intervals.Length; i++)
			{
				int[] nowArray = intervals[i];

				if (start != int.MinValue && end != int.MinValue)
				{
					//if ((nowArray[1] < start) || (nowArray[0] > end))     因為已經有排序過，不會發生 (nowArray[1] < start) 的情況了
					if (nowArray[0] > end)
					{
						ans.Add(new int[2] { start, end });

						start = nowArray[0];
						end = nowArray[1];
					}
					else
					{
						start = nowArray[0] < start ? nowArray[0] : start;
						end = nowArray[1] > end ? nowArray[1] : end;
					}
				}
				else
				{
					start = nowArray[0];
					end = nowArray[1];
				}

				// 把最後一組塞進去
				if (i == intervals.Length - 1)
				{
					ans.Add(new int[2] { start, end });
				}
			}

			return ans.ToArray();
		}
	}
}
