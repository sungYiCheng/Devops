using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /*
     * 242. Valid Anagram
Solved
Easy
Topics
Companies
Given two strings s and t, return true if t is an anagram of s, and false otherwise.

An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

 

Example 1:

Input: s = "anagram", t = "nagaram"
Output: true
Example 2:

Input: s = "rat", t = "car"
Output: false
 

Constraints:

1 <= s.length, t.length <= 5 * 104
s and t consist of lowercase English letters.
     * 
     */


    public partial class Solution
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            char[] sArray = s.ToCharArray();
            char[] tArray = t.ToCharArray();
            Dictionary<char, int> dic = new Dictionary<char, int>();
            for (int i = 0; i < sArray.Length; i++)
            {
                if (!dic.ContainsKey(sArray[i]))
                {
                    dic.Add(sArray[i], 1);
                }
                else
                {
                    dic[sArray[i]]++;
                }
            }

            bool check = true;
            for (int i = 0; i < tArray.Length; i++)
            {
                if (!dic.ContainsKey(tArray[i]))
                {
                    check = false;
                    break;
                }
                else
                {
                    if (dic[tArray[i]] == 0)
                    {
                        check = false;
                        break;
                    }

                    dic[tArray[i]]--;
                }
            }

            return check;
        }
    }
}
