﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	/*
	 * 3. Longest Substring Without Repeating Characters
Solved
Medium
Topics
Companies
Given a string s, find the length of the longest 
substring
 without repeating characters.

 

Example 1:

Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.
Example 2:

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
Example 3:

Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 

Constraints:

0 <= s.length <= 5 * 104
s consists of English letters, digits, symbols and spaces.
	 *
	 */


	public partial class Solution
	{
		public int LengthOfLongestSubstring(string s)
		{
			char[] charList = s.ToCharArray();
			int maxLength = 0;

			List<char> temp = new List<char>();
			for (int i = 0; i < s.Length; i++)
			{
				temp.Clear();

				for (int j = i; j < s.Length; j++)
				{
					if (!temp.Contains(charList[j]))
					{
						temp.Add(charList[j]);
						maxLength = Math.Max(maxLength, temp.Count);
					}
					else
					{

						break;
					}
				}
			}

			return maxLength;
		}
	}
}
