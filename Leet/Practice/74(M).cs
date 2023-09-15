using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public partial class Solution
	{
		/*
		 * 74. Search a 2D Matrix
Solved
Medium
Topics
Companies
You are given an m x n integer matrix matrix with the following two properties:

Each row is sorted in non-decreasing order.
The first integer of each row is greater than the last integer of the previous row.
Given an integer target, return true if target is in matrix or false otherwise.

You must write a solution in O(log(m * n)) time complexity.

 

Example 1:


Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3
Output: true
Example 2:


Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 13
Output: false
 

Constraints:

m == matrix.length
n == matrix[i].length
1 <= m, n <= 100
-104 <= matrix[i][j], target <= 104
		 * 
		 * 
		 */


		public bool SearchMatrix(int[][] matrix, int target)
		{
			List<int> list = new List<int>();

			for (int i = 0; i < matrix.Length; i++)
			{
				list.AddRange(matrix[i].ToList());
			}

			return list.Contains(target);
		}
	}
}
