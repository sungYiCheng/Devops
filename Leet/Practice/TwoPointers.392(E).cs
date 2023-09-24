using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /*
     * 
     * 392. Is Subsequence
Solved
Easy
Topics
Companies
Given two strings s and t, return true if s is a subsequence of t, or false otherwise.

A subsequence of a string is a new string that is formed from the original string by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters. (i.e., "ace" is a subsequence of "abcde" while "aec" is not).

 

Example 1:

Input: s = "abc", t = "ahbgdc"
Output: true
Example 2:

Input: s = "axc", t = "ahbgdc"
Output: false
 

Constraints:

0 <= s.length <= 100
0 <= t.length <= 104
s and t consist only of lowercase English letters.
     * 
     */


    public partial class Solution
    {
        public bool IsSubsequence(string s, string t)
        {
            char[] sArray = s.ToCharArray();
            List<char> tArray = t.ToCharArray().ToList();

            for (int i = 0; i < sArray.Length; i++)
            {
                if (tArray.Contains(sArray[i]))
                {
                    int index = tArray.FindIndex(x => x == sArray[i]);  // 這效能比較好
                    //int index = tArray.IndexOf(sArray[i]);

                    tArray.RemoveRange(0, index + 1);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
