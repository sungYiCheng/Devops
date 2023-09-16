using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /*
     * 57. Insert Interval
Solved
Medium
Topics
Companies
You are given an array of non-overlapping intervals intervals where intervals[i] = [starti, endi] represent the start and the end of the ith interval and intervals is sorted in ascending order by starti. You are also given an interval newInterval = [start, end] that represents the start and end of another interval.

Insert newInterval into intervals such that intervals is still sorted in ascending order by starti and intervals still does not have any overlapping intervals (merge overlapping intervals if necessary).

Return intervals after the insertion.

 

Example 1:

Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
Output: [[1,5],[6,9]]
Example 2:

Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
Output: [[1,2],[3,10],[12,16]]
Explanation: Because the new interval [4,8] overlaps with [3,5],[6,7],[8,10].
 

Constraints:

0 <= intervals.length <= 104
intervals[i].length == 2
0 <= starti <= endi <= 105
intervals is sorted by starti in ascending order.
newInterval.length == 2
0 <= start <= end <= 105
     */


    public partial class Solution
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            List<int[]> newIntervals = intervals.ToList();
            newIntervals.Add(newInterval);
            newIntervals.Sort((a, b) => { return a[0] - b[0]; });

            int start = int.MinValue;
            int end = int.MinValue;

            List<int[]> ans = new List<int[]>();
            for (int i = 0; i < newIntervals.Count; i++)
            {
                int[] nowArray = newIntervals[i];

                if (start != int.MinValue && end != int.MinValue)
                {
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

                if (i == newIntervals.Count - 1)
                {
                    ans.Add(new int[2] { start, end });
                }
            }

            return ans.ToArray();
        }
    }
}
