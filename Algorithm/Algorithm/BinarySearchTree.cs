using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public class TreeNode
    {
        public TreeNode Left { get; set; } = null;
        public TreeNode Right { get; set; } = null;
        public int Data { get; set; }

        public TreeNode(int data)
        {
            Data = data;
        }
    }

    public static class BinarySearchTree
    {
        public static TreeNode CreateTree()
        {
            TreeNode nodeRoot = new TreeNode(70)
            {

                Left = new TreeNode(30)
                {

                    Left = new TreeNode(20)
                    {
                        Left = new TreeNode(10),
                        Right = null
                    },

                    Right = new TreeNode(50)
                    {
                        Left = new TreeNode(40),
                        Right = new TreeNode(60)
                    }
                },
                Right = new TreeNode(80)
                {
                    Left = null,
                    Right = new TreeNode(90)
                }
            }; ;

            return nodeRoot;
        }

        // 前序走訪：root -> 左 -> 右
        public static void ForwardTraverse(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.Data);
            ForwardTraverse(node.Left);
            ForwardTraverse(node.Right);
        }

        // 中序走訪： 左 -> root -> 右
        public static void MiddleTraverse(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            MiddleTraverse(node.Left);
            Console.WriteLine(node.Data);
            MiddleTraverse(node.Right);
        }

        // 後序走訪： 左 -> 右 -> root
        public static void BackwardTraverse(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            BackwardTraverse(node.Left);
            BackwardTraverse(node.Right);
            Console.WriteLine(node.Data);
        }

        public static bool IsBTS(TreeNode node)
        {
            bool isBST = true;
            Stack<TreeNode> parentStack = new Stack<TreeNode>();
            int minValue = int.MinValue;

            while (parentStack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    parentStack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = parentStack.Pop();
                    if (node.Data <= minValue)
                    {
                        isBST = false;
                        break;
                    }
                    else
                    {
                        minValue = node.Data;
                    }

                    node = node.Right;
                }
            }

            return isBST;
        }


        /* 搜尋:
         * 
         * 每一何節點 資料 > 左子節點 且 < 右小節點
         * 左右子樹本身也是搜尋樹
         * 樹的每個節點值都不相同
         * 可以是空集合，但若不是，則節點上一定要有一個鍵值
         * 
         */

        public static bool Find(TreeNode node, int target)
        {
            if (node == null)
            {
                return false;
            }
            else if (target == node.Data)
            {
                return true;
            }
            else if (target > node.Data)
            {
                return Find(node.Right, target);
            }
            else
            {
                return Find(node.Left, target);
            }
        }

        // 插入
        public static bool Insert(TreeNode node, int value)
        {
            if (node == null)
            {
                node = new TreeNode(value);
                return true;
            }

            if (node.Data > value)
            {
                return Insert(node.Left, value);
            }
            else if (node.Data < value)
            {
                return Insert(node.Right, value);
            }

            return false;
        }


        // 刪除
        static bool Remove(TreeNode node, int value)
        {
            if (node == null)
            {
                return false;
            }

            if (node.Data > value)
            {
                return Remove(node.Left, value);
            }
            else if (node.Data < value)
            {
                return Remove(node.Right, value);
            }

            //都通過上方，代表找到 目標

            if (node.Left == null)  // 左子為空，直接用右子接上
            {
                TreeNode temp = node.Right;
                node = temp;
            }
            else if (node.Right == null)  // 右子為空，直接用左子接上
            {
                TreeNode temp = node.Left;
                node = temp;
            }
            else  // 右右都不為空，可以用 右子樹中最小的，或是 左子樹中最大的
            {
                // 這次選 右邊最小的
                int min = GetMin(node.Right);
                node.Data = min;

                if (Remove(node.Right, min))
                {
                    return false;
                }
            }

            return true;
        }

        private static int GetMin(TreeNode node)
        {
            if (node.Left != null)
			{
                return GetMin(node.Left);
            }

            return node.Data;
        }
    }
}
