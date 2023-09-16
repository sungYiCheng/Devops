using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /*
     * 205. Isomorphic Strings
Solved
Easy
Topics
Companies
Given two strings s and t, determine if they are isomorphic.

Two strings s and t are isomorphic if the characters in s can be replaced to get t.

All occurrences of a character must be replaced with another character while preserving the order of characters. No two characters may map to the same character, but a character may map to itself.

 

Example 1:

Input: s = "egg", t = "add"
Output: true
Example 2:

Input: s = "foo", t = "bar"
Output: false
Example 3:

Input: s = "paper", t = "title"
Output: true
 

Constraints:

1 <= s.length <= 5 * 104
t.length == s.length
s and t consist of any valid ascii character.
     */

    public partial class Solution
    {
        public bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            char[] sArray = s.ToCharArray();
            char[] tArray = t.ToCharArray();

            Dictionary<char, char> mapping = new Dictionary<char, char>();
            Dictionary<char, char> mappingRevr = new Dictionary<char, char>();

            // 多個反向，是為了避免  "abc", "eed" 的情況，沒有反向這樣會相同


            bool check = true;
            for (int i = 0; i < sArray.Length; i++)
            {
                if (!mapping.ContainsKey(sArray[i]))
                {
                    if (!mappingRevr.ContainsKey(tArray[i]))
                    {
                        mapping.Add(sArray[i], tArray[i]);
                        mappingRevr.Add(tArray[i], sArray[i]);
                        continue;
                    }
                    else
                    {
                        check = false;
                        break;
                    }
                }
                else
                {
                    if (mapping[sArray[i]] != tArray[i])
                    {
                        check = false;
                        break;
                    }
                }
            }

            return check;
        }
    }
}
