using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	/*82. Remove Duplicates from Sorted List II
Solved
Medium
Topics
Companies
Given the head of a sorted linked list, delete all nodes that have duplicate numbers, leaving only distinct numbers from the original list. Return the linked list sorted as well.

 

Example 1:


Input: head = [1,2,3,3,4,4,5]
Output: [1,2,5]
Example 2:


Input: head = [1,1,1,2,3]
Output: [2,3]
 

Constraints:

The number of nodes in the list is in the range [0, 300].
-100 <= Node.val <= 100
The list is guaranteed to be sorted in ascending order.
	 */

	public partial class Solution
	{
		public ListNode DeleteDuplicates1(ListNode head)
		{
			Dictionary<int, int> listNumDic = new Dictionary<int, int>();
			List<ListNode> list = new List<ListNode>();

			while (head != null)
			{
				if (!listNumDic.ContainsKey(head.val))
				{
					listNumDic.Add(head.val, 1);
				}
				else
				{
					listNumDic[head.val]++;
				}

				ListNode node = new ListNode { val = head.val, next = null };

				list.Add(node);
				head = head.next;
			}

			ListNode startHead = null;
			ListNode now = null;
			foreach (ListNode node in list)
			{
				if (listNumDic[node.val] > 1)
				{
					continue;
				}

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
