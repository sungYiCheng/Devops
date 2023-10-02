using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public class Important
	{
		public class NiceSkill
		{
			string str = string.Empty;
			char ch = 'A';
			int num = 123;
			Stack<int> stack = new Stack<int>();
			List<int[]> listlist = null;
			List<int> list = null;
            int[] array = null;


            public NiceSkill() 
			{
				// remove all
                List<string> list = str.Split(" ").ToList();
                list.Reverse();
                list.RemoveAll(x => x == string.Empty);

                // 重要技巧，不然int轉char會有 多餘的符號
                char c = (char)(num + '0');

                // 重要技巧，不然int轉char[]的好方法
                char[] nlst = num.ToString().ToCharArray();

                // 把字串照字母順序排序
                string ans = string.Concat(str.OrderBy(c => c));

				// 判斷
				bool flag = int.TryParse(str, out int num2222);

				// ch 轉 int
                int nummmmm = (ch - '0');

                // 照array 0 排序 小->大
                listlist.Sort((a, b) => { return a[0] - b[0]; });

                // 把字串照字母順序排序
                string strrrrrr = String.Concat(list.OrderBy(c => c));

                // 把arry 或 list 串成字串
                string strrrr = string.Join(",", list);
                string strrrr2 = string.Join("", list);

                //
                int startIndex = 0;
                int count = 0;
                int target = 999;
                int index = Array.FindIndex(array, startIndex, count, x => x == target);
            }
		}

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

            "122. Best Time to Buy and Sell Stock II",
            "134. Gas Station",
            "215. Kth Largest Element in an Array",
            "1456. Maximum Number of Vowels in a Substring of Given Length",
            "394. Decode String",

            "735. Asteroid Collision",
            "202. Happy Number",


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
