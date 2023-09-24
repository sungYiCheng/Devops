using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	/*86. Partition List
Solved
Medium
Topics
Companies
Given the head of a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.

You should preserve the original relative order of the nodes in each of the two partitions.

 

Example 1:


Input: head = [1,4,3,2,5,2], x = 3
Output: [1,2,2,4,3,5]
Example 2:

Input: head = [2,1], x = 2
Output: [1,2]
 

Constraints:

The number of nodes in the list is in the range [0, 200].
-100 <= Node.val <= 100
-200 <= x <= 200
	 */



	public partial class Solution
	{
		public ListNode Partition(ListNode head, int x)
		{
			if (x <= 1)
			{
				return head;
			}

			List<ListNode> samllList = new List<ListNode>();
			List<ListNode> list = new List<ListNode>();

			while (head != null)
			{
				ListNode node = new ListNode { val = head.val, next = null };

				if (head.val < x)
				{
					samllList.Add(node);
				}
				else
				{
					list.Add(node);
				}

				head = head.next;
			}

			ListNode startHead = null;
			ListNode now = null;
			foreach (ListNode node in samllList)
			{
				if (startHead == null)
				{
					startHead = node;
				}
				else
				{
					now.next = node;
				}

				now = node;
			}

			ListNode newStartHead = now == null ? now : startHead;
			foreach (ListNode node in list)
			{
				if (newStartHead == null)
				{
					newStartHead = node;
				}
				else
				{
					now.next = node;
				}

				now = node;
			}

			return startHead;
		}
	}
}
