using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	/*
	 * 125. Valid Palindrome
Solved
Easy
Topics
Companies
A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

Given a string s, return true if it is a palindrome, or false otherwise.

 

Example 1:

Input: s = "A man, a plan, a canal: Panama"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome.
Example 2:

Input: s = "race a car"
Output: false
Explanation: "raceacar" is not a palindrome.
Example 3:

Input: s = " "
Output: true
Explanation: s is an empty string "" after removing non-alphanumeric characters.
Since an empty string reads the same forward and backward, it is a palindrome.
 

Constraints:

1 <= s.length <= 2 * 105
s consists only of printable ASCII characters.
	 * 
	 * 
	 * 
	 */

	public partial class Solution
	{
		public bool IsPalindrome(string s)
		{
			char[] array = s.ToCharArray();
			List<char> resetArray = new List<char>();

			int ASCII_0 = Convert.ToInt32('0');
			int ASCII_9 = Convert.ToInt32('9');
			int ASCII_a = Convert.ToInt32('a');
			int ASCII_z = Convert.ToInt32('z');

			for (int i = 0; i < array.Length; i++)
			{
				char low = char.ToLower(array[i]);
				int lowNum = Convert.ToInt32(low);

				if (lowNum >= ASCII_0 && lowNum <= ASCII_9)
				{
					resetArray.Add(low);
				}
				else if (lowNum >= ASCII_a && lowNum <= ASCII_z)
				{
					resetArray.Add(low);
				}
			}

			bool check = true;
			for (int j = 0; j < resetArray.Count; j++)
			{
				int endIndex = resetArray.Count - 1 - j;

				if (j > endIndex)
				{
					break;
				}

				char start = resetArray[j];
				char end = resetArray[endIndex];

				if (start != end)
				{
					check = false;
					break;
				}
			}

			return check;
		}
	}
}
