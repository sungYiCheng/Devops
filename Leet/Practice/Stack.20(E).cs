using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	/*20. Valid Parentheses
	 * Easy
Topics
Companies
Hint
Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
Every close bracket has a corresponding open bracket of the same type.
 

Example 1:

Input: s = "()"
Output: true
Example 2:

Input: s = "()[]{}"
Output: true
Example 3:

Input: s = "(]"
Output: false
 

Constraints:

1 <= s.length <= 104
s consists of parentheses only '()[]{}'.
	 */
	public partial class Solution
	{
		public bool IsValid(string s)
		{
			Dictionary<string, string> dic = new Dictionary<string, string>();
			dic.Add("(", ")");
			dic.Add("[", "]");
			dic.Add("{", "}");

			char[] strArray = s.ToCharArray();

			if (strArray.Length % 2 > 0)
			{
				return false;
			}

			bool flag = true;
			Stack<char> check = new Stack<char>();

			for (int i = 0; i < strArray.Length; ++i)
			{
				if (dic.ContainsKey(strArray[i].ToString()))
				{
					check.Push(strArray[i]);
				}
				else
				{
					if (check.Count == 0)
					{
						flag = false;
						break;
					}

					char left = check.Pop();
					if (dic.TryGetValue(left.ToString(), out string mapping))
					{
						if (mapping != strArray[i].ToString())
						{
							flag = false;
						}
					}
				}
			}

			if (check.Count > 0)
			{
				flag = false;
			}

			return flag;
		}
	}
}
