using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public TreeNode DeleteNode(TreeNode root, int key)
        {

            Remove(root, key);

            return root;
        }

        public bool Remove(TreeNode node, int value)
        {
            if (node == null)
            {
                return false;
            }

            if (node.val > value)
            {
                return Remove(node.left, value);
            }
            else if (node.val < value)
            {
                return Remove(node.right, value);
            }

            //都通過上方，代表找到 目標

            if (node.left == null && node.right == null)
            {
                node = null;
            }
            else if (node.left == null)  // 左子為空，直接用右子接上
            {
                TreeNode temp = node.right;
                node = temp;
            }
            else if (node.right == null)  // 右子為空，直接用左子接上
            {
                TreeNode temp = node.left;
                node = temp;
            }
            else  // 右右都不為空，可以用 右子樹中最小的，或是 左子樹中最大的
            {
                // 這次選 右邊最小的
                int min = GetMin(node.right);
                node.val = min;

                if (Remove(node.right, min))
                {
                    return false;
                }
            }

            return true;
        }

        public int GetMin(TreeNode node)
        {
            if (node.left != null)
            {
                return GetMin(node.left);
            }

            return node.val;
        }



        public TreeNode Remove2(TreeNode node, int value)
        {
            if (node == null)
            {
                return node;
            }

            if (node.val > value)
            {
                node.left = Remove2(node.left, value);
            }
            else if (node.val < value)
            {
                node.right = Remove2(node.right, value);
            }
            else
            {



                //都通過上方，代表找到 目標

                if (node.left == null && node.right == null)
                {
                    node = null;   // 不知道怎麼把它變成null
                }
                else if (node.left == null)  // 左子為空，直接用右子接上
                {
                    node = node.right;
                }
                else if (node.right == null)  // 右子為空，直接用左子接上
                {
                    node = node.left;
                }
                else  // 右右都不為空，可以用 右子樹中最小的，或是 左子樹中最大的
                {
                    // 這次選 右邊最小的
                    int min = GetMin(node.right);
                    node.val = min;

                    node.right = Remove2(node.right, min);
                }
            }
            return node;
        }
    }
}
