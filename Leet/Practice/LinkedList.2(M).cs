using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	/*2. Add Two Numbers
Solved
Medium
Topics
Companies
You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

 

Example 1:


Input: l1 = [2,4,3], l2 = [5,6,4]
Output: [7,0,8]
Explanation: 342 + 465 = 807.

Example 2:

Input: l1 = [0], l2 = [0]
Output: [0]
Example 3:

Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
Output: [8,9,9,9,0,0,0,1]
 

Constraints:

The number of nodes in each linked list is in the range [1, 100].
0 <= Node.val <= 9
It is guaranteed that the list represents a number that does not have leading zeros.
	 */

	public partial class Solution
	{
		public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
		{
			ListNode start = null;
			ListNode startHead = null;
			int val_1 = 0;
			int val_2 = 0;
			int plus = 0;
			int val = 0;
			while (l1 != null || l2 != null)
			{
				val_1 = 0;
				val_2 = 0;

				if (l1 != null)
				{
					val_1 = l1.val;
					l1 = l1.next;
				}

				if (l2 != null)
				{
					val_2 = l2.val;
					l2 = l2.next;
				}

				int tempSum = val_1 + val_2 + plus;

				if (tempSum >= 10)
				{
					val = tempSum - 10;
					plus = 1;
				}
				else
				{
					val = tempSum;
					plus = 0;
				}

				ListNode node = new ListNode(val, null);

				if (start == null)
				{
					start = node;
					startHead = node;
				}
				else
				{
					start.next = node;
					start = start.next;
				}

				if (l1 == null && l2 == null && plus == 1)
				{
					ListNode node2 = new ListNode(plus, null);
					start.next = node2;
				}
			}

			return startHead;
		}
	}
}
