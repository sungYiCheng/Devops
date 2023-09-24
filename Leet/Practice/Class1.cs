using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public partial class Solution
	{

        public int diagonalDifference(List<List<int>> arr)
        {
            List<int> numList = arr.First();
            arr.Remove(numList);

            int left = 0;
            int right = 0;

            int n = numList.First();
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    if (i == k)
                    {
                        left += arr[i][k];
                    }

                    if (k == n - 1 - i)
                    {
                        right += arr[i][k];
                    }
                }
            }

            return Math.Abs(left - right);
        }
    }
}
