using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public partial class Solution
    {
        public int EqualPairs(int[][] grid)
        {
            List<string> rowList = new List<string>();
            List<string> columList = new List<string>();

            for (int i = 0; i < grid.Length; i++)
            {
                string str = string.Join(",", grid[i]);
                rowList.Add(str);

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
