using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public class Important
	{
		List<string> Qu = new List<string>()
		{
			"11. Container With Most Water",
			"134. Gas Station",
			"443. String Compression",
			"334. Increasing Triplet Subsequence",
			"12. Integer to Roman",
			"45. Jump Game II",
			"6. Zigzag Conversion",
			"605. Can Place Flowers",

		};
	}


	public class ListNode
	{

		public int val;
		public ListNode next;
		public ListNode(int x)
		{
			val = x;
			next = null;
		}

		public ListNode(int val = 0, ListNode next = null)
		{
			this.val = val;
			this.next = next;
		}
	}

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
