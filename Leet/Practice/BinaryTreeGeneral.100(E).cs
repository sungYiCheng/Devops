using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{

    /*
	 * 100. Same Tree
Solved
Easy
Topics
Companies
Given the roots of two binary trees p and q, write a function to check if they are the same or not.

Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.

 

Example 1:


Input: p = [1,2,3], q = [1,2,3]
Output: true
Example 2:


Input: p = [1,2], q = [1,null,2]
Output: false
Example 3:


Input: p = [1,2,1], q = [1,1,2]
Output: false
 

Constraints:

The number of nodes in both trees is in the range [0, 100].
-104 <= Node.val <= 104
	 * 
	 * 
	 */


    public partial class Solution
    {
        public bool isSameTree(TreeNode p, TreeNode q)
        {
            return _isSameTree(p, q);
        }

        public bool _isSameTree(TreeNode p, TreeNode q)
        {
            if ((p == null && q != null) || (p != null && q == null))
            {
                return false;
            }

            if (p != null && q != null)
            {
                if (p.val != q.val)
                {
                    return false;
                }

                return _isSameTree(p.right, q.right) && _isSameTree(p.left, q.left);
            }
            else
            {
                return true;
            }
        }
    };
}
