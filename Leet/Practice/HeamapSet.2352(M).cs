using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /*
     * 2352. Equal Row and Column Pairs
Solved
Medium
Topics
Companies
Hint
Given a 0-indexed n x n integer matrix grid, return the number of pairs (ri, cj) such that row ri and column cj are equal.

A row and column pair is considered equal if they contain the same elements in the same order (i.e., an equal array).

 

Example 1:

    (有圖)


Input: grid = [[3,2,1],[1,7,6],[2,7,7]]
Output: 1
Explanation: There is 1 equal row and column pair:
- (Row 2, Column 1): [2,7,7]
Example 2:

        (有圖)

Input: grid = [[3,1,2,2],[1,4,4,5],[2,4,2,2],[2,4,2,2]]
Output: 3
Explanation: There are 3 equal row and column pairs:
- (Row 0, Column 0): [3,1,2,2]
- (Row 2, Column 2): [2,4,2,2]
- (Row 3, Column 2): [2,4,2,2]
 

Constraints:

n == grid.length == grid[i].length
1 <= n <= 200
1 <= grid[i][j] <= 105
     * 
     */


    public partial class Solution
    {
        public int EqualPairs(int[][] grid)
        {
            List<string> rowList = new List<string>();
            List<string> columList = new List<string>();

            for (int i = 0; i < grid.Length; i++)
            {
                // 橫的 串成字串
                string str = string.Join(",", grid[i]);
                rowList.Add(str);

                // 直的 串成字串
                List<int> colum = new List<int>();
                for (int j = 0; j < grid[i].Length; j++) 
                {
                    colum.Add(grid[j][i]);
                }

                str = string.Join(",", colum);
                columList.Add(str);
            }

            return CountStrList(rowList, columList); ;
        }

        private int CountStrList(List<string> rowList, List<string> columList)
        {
            int count = 0;
            //List<string> alreay = new List<string>();

            foreach (string rowStr in rowList)
            {
                foreach (string colStr in columList)
                {
                    if(rowStr == colStr)
                    {
                         count++;
                    }
                }
            }


                return count;
        }
    }
}
