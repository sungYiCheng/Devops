﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practice
{
    /*
     * 443. String Compression
Solved
Medium
Topics
Companies
Hint
Given an array of characters chars, compress it using the following algorithm:

Begin with an empty string s. For each group of consecutive repeating characters in chars:

If the group's length is 1, append the character to s.
Otherwise, append the character followed by the group's length.
The compressed string s should not be returned separately, but instead, be stored in the input character array chars. Note that group lengths that are 10 or longer will be split into multiple characters in chars.

After you are done modifying the input array, return the new length of the array.

You must write an algorithm that uses only constant extra space.

 

Example 1:

Input: chars = ["a","a","b","b","c","c","c"]
Output: Return 6, and the first 6 characters of the input array should be: ["a","2","b","2","c","3"]
Explanation: The groups are "aa", "bb", and "ccc". This compresses to "a2b2c3".
Example 2:

Input: chars = ["a"]
Output: Return 1, and the first character of the input array should be: ["a"]
Explanation: The only group is "a", which remains uncompressed since it's a single character.
Example 3:

Input: chars = ["a","b","b","b","b","b","b","b","b","b","b","b","b"]
Output: Return 4, and the first 4 characters of the input array should be: ["a","b","1","2"].
Explanation: The groups are "a" and "bbbbbbbbbbbb". This compresses to "ab12".
 

Constraints:

1 <= chars.length <= 2000
chars[i] is a lowercase English letter, uppercase English letter, digit, or symbol.
     * 
     * 
     * 
     */

    public partial class Solution
    {
        public int Compress(char[] chars)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            List<char> list = new List<char>();

            for (int i = 0; i < chars.Length; i++)
            {
                if (!dic.ContainsKey(chars[i]))
                {
                    SetDic(dic, list);

                    dic.Add(chars[i], 1);
                }
                else
                {
                    dic[chars[i]]++;
                }
            }

            // 最後一組也要處理
            SetDic(dic, list);

            for (int i = 0; i < list.Count(); i++)
            {
                chars[i] = list[i];
            }

            return list.Count();
        }

        private void SetDic(Dictionary<char, int> dic, List<char> list)
        {
            foreach (KeyValuePair<char, int> pir in dic)
            {
                if (pir.Value == 1)
                {
                    list.Add(pir.Key);
                }
                else
                {
                    list.Add(pir.Key);

                    if (pir.Value < 10)
                    {
                        // 重要技巧，不然int轉char會有 多餘的符號
                        char c = (char)(pir.Value + '0');
                        list.Add(c);
                    }
                    else
                    {
                        // 重要技巧，不然int轉char[]的好方法
                        char[] nlst = pir.Value.ToString().ToCharArray();
                        list.AddRange(nlst);
                    }
                }
            }

            dic.Clear();
        }
    }
}
