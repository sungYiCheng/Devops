using System;
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
Given a string s, find the length of the longest substring without repeating characters.

 
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
     * 
     */
    public partial class Solution
    {
        // 解法1 (較優)
        public int LengthOfLongestSubstring(string s)
        {
            char[] charList = s.ToCharArray();
            int maxLength = 0;

            List<char> temp = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (temp.Contains(charList[i]))   // 只要發現tamp內有重複，把tamp內 "重複+之前" 的都刪掉
                {
                    int index = temp.IndexOf(charList[i]);
                    temp.RemoveRange(0, index + 1);
                }

                // 補上這次新的，再種比一次 最大長度
                temp.Add(charList[i]);
                maxLength = Math.Max(maxLength, temp.Count);
            }

            return maxLength;
        }

        // 解法2
        public int LengthOfLongestSubstring2(string s)
        {
            char[] charList = s.ToCharArray();
            int maxLength = 0;

            List<char> temp = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                //  就是一個一個檢查
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
