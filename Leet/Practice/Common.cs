using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public class ListNode
	{
		public List<int> Important = new List<int>()
		{
			134, 
		};

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
}
