using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	/*
	 * 
	 * 101. Symmetric Tree
Solved
Easy
Topics
Companies
Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).

 

Example 1:


Input: root = [1,2,2,3,4,4,3]
Output: true
Example 2:


Input: root = [1,2,2,null,3,null,3]
Output: false
 

Constraints:

The number of nodes in the tree is in the range [1, 1000].
-100 <= Node.val <= 100
	 * 
	 */


	/**
	 * Definition for a binary tree node.
	 * public class TreeNode {
	 *     public int val;
	 *     public TreeNode left;
	 *     public TreeNode right;
	 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
	 *         this.val = val;
	 *         this.left = left;
	 *         this.right = right;
	 *     }
	 * }
	 */
	public partial class Solution
	{
		public bool IsSymmetric(TreeNode root)
		{
			return check(root.left, root.right);
		}

		public bool check(TreeNode L, TreeNode R)
		{
			if (L == null && R == null)
			{
				return true;
			}
			else if (L != null && R != null)
			{
				if (L.val != R.val)
				{
					return false;
				}

				return check(L.left, R.right) && check(L.right, R.left);
			}
			else
			{
				return false;
			}
		}
	}
}
