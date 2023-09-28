using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	/*
	 * 
	 * 
Code

Testcase
Testcase
Result

226. Invert Binary Tree
Solved
Easy
Topics
Companies
Given the root of a binary tree, invert the tree, and return its root.

 

Example 1:


Input: root = [4,2,7,1,3,6,9]
Output: [4,7,2,9,6,3,1]
Example 2:


Input: root = [2,1,3]
Output: [2,3,1]
Example 3:

Input: root = []
Output: []
 

Constraints:

The number of nodes in the tree is in the range [0, 100].
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
		public TreeNode InvertTree(TreeNode root)
		{
			Set(root);

			return root;
		}

		public void Set(TreeNode root)
		{
			if (root == null)
			{
				return;
			}

			TreeNode L = root.left;
			TreeNode R = root.right;

			root.left = R;
			root.right = L;

			Set(root.left);
			Set(root.right);
		}
	}
}
