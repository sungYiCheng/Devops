using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
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
        public TreeNode SearchBST(TreeNode root, int val)
        {
            Find(root, val, out TreeNode node);
            
            return node;
        }


        public bool Find(TreeNode node, int target, out TreeNode findNode)
        {
            findNode = null;
            if (node == null)
            {
                return false;
            }
            else if (target == node.val)
            {
                findNode = node;
                return true;
            }
            else if (target > node.val)
            {
                return Find(node.right, target, out findNode);
            }
            else
            {
                return Find(node.left, target, out findNode);
            }
        }
    }
}
