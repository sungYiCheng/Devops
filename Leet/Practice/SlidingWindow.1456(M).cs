using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public partial class Solution
    {
		/*
         * 1456. Maximum Number of Vowels in a Substring of Given Length
Attempted
Medium
Topics
Companies
Hint
Given a string s and an integer k, return the maximum number of vowel letters in any substring of s with length k.

Vowel letters in English are 'a', 'e', 'i', 'o', and 'u'.

 

Example 1:

Input: s = "abciiidef", k = 3
Output: 3
Explanation: The substring "iii" contains 3 vowel letters.
Example 2:

Input: s = "aeiou", k = 2
Output: 2
Explanation: Any substring of length 2 contains 2 vowels.
Example 3:

Input: s = "leetcode", k = 3
Output: 2
Explanation: "lee", "eet" and "ode" contain 2 vowels.
 

Constraints:

1 <= s.length <= 105
s consists of lowercase English letters.
1 <= k <= s.length
         * 
         * "weallloveyou" k = 7
         */

		public int MaxVowels(string s, int k)
        {
            char[] chars = s.ToCharArray();
            int count = 0;

            // K個字母為一個框框，先算出第一組框框中有多少個母音
            for (int j = 0; j < k; j++)
            {
                if (isVowel(chars[j]))
				{
                    count++;
                }
            }

            // 開始慢慢前進，每往前一步，檢查框框新加入的是不是母音(是就+1)，框框最後一個是不是母音(不是就-1)，依此類推，每移動一次都看跟前一次框框的變化量
            // 只要框框頭尾就可以，因為只有這兩個再增減，其餘中間都一樣
            int max = count;
            for (int i = k; i < chars.Length; i++)
			{
                // 
                if (isVowel(chars[i - k]))
				{
                    count--;
                }

                if (isVowel(chars[i]))
				{
                    count++;
				}

                max = Math.Max(max, count);
            }

            return max;
        }


		public bool isVowel(char c)
        {
            return (c == 'a') || (c == 'e') || (c == 'i') || (c == 'o') || (c == 'u');
        }
    }
}
