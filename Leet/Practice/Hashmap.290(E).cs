using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /*

290. Word Pattern
Solved
Easy
Topics
Companies
Given a pattern and a string s, find if s follows the same pattern.

Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in s.

 

Example 1:

Input: pattern = "abba", s = "dog cat cat dog"
Output: true
Example 2:

Input: pattern = "abba", s = "dog cat cat fish"
Output: false
Example 3:

Input: pattern = "aaaa", s = "dog cat cat dog"
Output: false
 

Constraints:

1 <= pattern.length <= 300
pattern contains only lower-case English letters.
1 <= s.length <= 3000
s contains only lowercase English letters and spaces ' '.
s does not contain any leading or trailing spaces.
All the words in s are separated by a single space.
     */
    public partial class Solution
    {
        public bool WordPattern(string pattern, string s)
        {
            string[] sArray = s.Split(" ");
            if (pattern.Length != sArray.Length)
            {
                return false;
            }

            char[] pattenArray = pattern.ToCharArray();
            Dictionary<char, string> mapping = new Dictionary<char, string>();
            Dictionary<string, char> mappingRevr = new Dictionary<string, char>();

            bool check = true;
            for (int i = 0; i < pattenArray.Length; i++)
            {
                if (!mapping.ContainsKey(pattenArray[i]))
                {
                    if (!mappingRevr.ContainsKey(sArray[i]))
                    {
                        mapping.Add(pattenArray[i], sArray[i]);
                        mappingRevr.Add(sArray[i], pattenArray[i]);
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
                    if (mapping[pattenArray[i]] != sArray[i])
                    {
                        check = false;
                        break;
                    }
                }
            }

            return check;
        }
    }