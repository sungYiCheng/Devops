using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	/*
	 * 19. Remove Nth Node From End of List
Solved
Medium
Topics
Companies
Hint
Given the head of a linked list, remove the nth node from the end of the list and return its head.

 

Example 1:


Input: head = [1,2,3,4,5], n = 2
Output: [1,2,3,5]
Example 2:

Input: head = [1], n = 1
Output: []
Example 3:

Input: head = [1,2], n = 1
Output: [1]
 

Constraints:

The number of nodes in the list is sz.
1 <= sz <= 30
0 <= Node.val <= 100
1 <= n <= sz
	 */

	public partial class Solution
	{
		public ListNode RemoveNthFromEnd2(ListNode head, int n)
		{
			List<ListNode> list = new List<ListNode>();

			while (head != null)
			{
				ListNode node = new ListNode { val = head.val, next = null };

				list.Add(node);
				head = head.next;
			}

			list.RemoveAt(list.Count - n);

			ListNode startHead = null;
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

		public ListNode RemoveNthFromEnd(ListNode head, int n)
		{
			List<ListNode> list = new List<ListNode>();

			ListNode start = head;

			while (head != null)
			{
				list.Add(head);
				head = head.next;
			}

			int totalCount = list.Count;
			list.RemoveAt(list.Count - n);

			if ( n == 1)
			{
				if (list.Count == 0)
				{
					return null;
				}
				else
				{
					list.Last().next = null;
				}
			}
			else
			{
				int indexPre = totalCount - n - 1;
				int indexNext = list.Count - n + 1;

				list[indexPre].next = list[indexNext];
			}

			return start;
		}

	}
}
