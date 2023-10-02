using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	/*
	 * 5. Longest Palindromic Substring
Solved
Medium
Topics
Companies
Hint
Given a string s, return the longest 
palindromic
 
substring
 in s.

 

Example 1:

Input: s = "babad"
Output: "bab"
Explanation: "aba" is also a valid answer.
Example 2:

Input: s = "cbbd"
Output: "bb"
 

Constraints:

1 <= s.length <= 1000
s consist of only digits and English letters.
	 */

	public partial class Solution
	{
		public string LongestPalindrome(string s)
		{
			string maxStr = string.Empty;
			char[] array = s.ToCharArray();

			for (int i = 0; i < array.Length; i++)
			{
				string subStr = s.Substring(i);

				if (maxStr.Length >= subStr.Length)
				{
					break;
				}

				string temp = Find(subStr);

				if (temp.Length > maxStr.Length)
				{
					maxStr = temp;
				}
			}

			return maxStr;
		}

		public string Find(string source)
		{
			char[] array = source.ToCharArray();

			List<char> target = new List<char>();
			string maxStr = string.Empty;
			for (int i = 0; i < array.Length; i++)
			{
				target.Add(array[i]);

				char[] tempTaget = target.ToArray();
				if (IsPalindrome(tempTaget))
				{
					if (target.Count > maxStr.Length)
					{
						maxStr = new string(tempTaget);
					}
				}
			}

			return maxStr;
		}

		public bool IsPalindrome(char[] array)
		{
			bool flag = true;
			for (int i = 0; i <= array.Length / 2; i++)
			{
				if (array[i] != array[array.Length - 1 - i])
				{
					flag = false;
				}
			}

			return flag;
		}
	}
}
