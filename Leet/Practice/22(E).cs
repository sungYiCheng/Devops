using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /*21. Merge Two Sorted Lists
Solved
Easy
Topics
Companies
You are given the heads of two sorted linked lists list1 and list2.

Merge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.

Return the head of the merged linked list.

 

Example 1:


Input: list1 = [1,2,4], list2 = [1,3,4]
Output: [1,1,2,3,4,4]
Example 2:

Input: list1 = [], list2 = []
Output: []
Example 3:

Input: list1 = [], list2 = [0]
Output: [0]
 

Constraints:

The number of nodes in both lists is in the range [0, 50].
-100 <= Node.val <= 100
Both list1 and list2 are sorted in non-decreasing order.
	 */
    public partial class Solution
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode newList = null;

            if (list1 == null && list2 == null)
            {
                return newList;
            }
            else if (list1 == null && list2 != null)
            {
                newList = list2;
                return newList;
            }
            else if (list1 != null && list2 == null)
            {
                newList = list1;
                return newList;
            }


            newList = new ListNode();
            if (list1.val <= list2.val)
            {
                newList.val = list1.val;
                Link(newList, list1.next, list2);
            }
            else
            {
                newList.val = list2.val;
                Link(newList, list1, list2.next);
            }

            return newList;
        }

        private void Link(ListNode nowList, ListNode list1, ListNode list2)
        {
            if (list1 == null)
            {
                nowList.next = list2;
                return;
            }
            else if (list2 == null)
            {
                nowList.next = list1;
                return;
            }


            ListNode newList = new ListNode();

            if (list1.val <= list2.val)
            {
                newList.val = list1.val;
                nowList.next = newList;

                Link(newList, list1.next, list2);
            }
            else
            {
                newList.val = list2.val;
                nowList.next = newList;

                Link(newList, list1, list2.next);
            }
        }
    }
}
