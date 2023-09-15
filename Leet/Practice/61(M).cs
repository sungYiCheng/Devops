using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	/*
	 * 61. Rotate List
	 * Medium
	 * 

Topics
Companies
	 * Given the head of a linked list, rotate the list to the right by k places.

 

Example 1:


Input: head = [1,2,3,4,5], k = 2
Output: [4,5,1,2,3]
Example 2:


Input: head = [0,1,2], k = 4
Output: [2,0,1]
 

Constraints:

The number of nodes in the list is in the range [0, 500].
-100 <= Node.val <= 100
0 <= k <= 2 * 109
	 */

	public partial class Solution
	{
		public ListNode RotateRight(ListNode head, int k)
		{
			List<ListNode> list = new List<ListNode>();
			ListNode startHead = head;

			while (head != null)
			{
				ListNode node = new ListNode { val = head.val, next = null };

				list.Add(node);
				head = head.next;
			}

			if (list.Count == 0)
			{
				return startHead;
			}

			// 找出循環幾次後，最終會輪轉的次數
			int count = k % list.Count;

			for (int i = 0; i < count; i++)
			{
				ListNode last = list.Last();

				// 從後面刪掉，從前面塞進去
				list.RemoveAt(list.Count - 1);
				list.Insert(0, last);
			}

			startHead = null;
			ListNode now = null;
			foreach (ListNode node in list)
			{
				if (startHead == null)
				{
					startHead = node;
					now = node;
				}
				else
				{
					now.next = node;
					now = node;
				}
			}

			return startHead;
		}
	}
}
