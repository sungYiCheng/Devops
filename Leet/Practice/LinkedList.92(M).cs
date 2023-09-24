using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	/*
	92. Reverse Linked List II
Solved
Medium
Topics
Companies
Given the head of a singly linked list and two integers left and right where left <= right, reverse the nodes of the list from position left to position right, and return the reversed list.

 

Example 1:


Input: head = [1,2,3,4,5], left = 2, right = 4
Output: [1,4,3,2,5]
Example 2:

Input: head = [5], left = 1, right = 1
Output: [5]
 

Constraints:

The number of nodes in the list is n.
1 <= n <= 500
-500 <= Node.val <= 500
1 <= left <= right <= n
	*/

	public partial class Solution
	{
		public ListNode ReverseBetween(ListNode head, int left, int right)
		{
			ListNode startHead = head;
			ListNode cut1 = null;
			ListNode cut2 = null;

			bool start = false;
			List<ListNode> list = new List<ListNode>();
			int count = 1;
			while (head != null)
			{
				if (count == left)
				{
					start = true;
				}

				if (count == right)
				{
					list.Add(head);
					cut2 = head.next;

					break;
				}

				if (start)
				{
					list.Add(head);
				}
				else
				{
					cut1 = head;
				}

				head = head.next;
				count++;
			}

			list.Reverse();

			foreach (ListNode node in list)
			{
				if (cut1 == null)
				{
					startHead = node;
					cut1 = node;
				}
				else
				{
					cut1.next = node;
					cut1 = node;
				}
			}
			cut1.next = cut2;

			return startHead;
		}
	}
}
