using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public class Important
	{
		List<string> Qu = new List<string>();

		public Important()
		{
			Qu.Add("11. Container With Most Water");
			Qu.Add("134. zzzz");
            Qu.Add("443. String Compression");
			Qu.Add("334. Increasing Triplet Subsequence");
        }

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
}
