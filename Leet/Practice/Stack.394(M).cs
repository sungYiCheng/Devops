using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /*
     * 394. Decode String
Medium
Topics
Companies
Given an encoded string, return its decoded string.

The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times. Note that k is guaranteed to be a positive integer.

You may assume that the input string is always valid; there are no extra white spaces, square brackets are well-formed, etc. Furthermore, you may assume that the original data does not contain any digits and that digits are only for those repeat numbers, k. For example, there will not be input like 3a or 2[4].

The test cases are generated so that the length of the output will never exceed 105.

 

Example 1:

Input: s = "3[a]2[bc]"
Output: "aaabcbc"
Example 2:

Input: s = "3[a2[c]]"
Output: "accaccacc"
Example 3:

Input: s = "2[abc]3[cd]ef"
Output: "abcabccdcdcdef"
 

Constraints:

1 <= s.length <= 30
s consists of lowercase English letters, digits, and square brackets '[]'.
s is guaranteed to be a valid input.
All the integers in s are in the range [1, 300].
     * 
     * 
     */


    public partial class Solution
    {
        public string DecodeString(string s)
        {
            var stack = new Stack<string>();

            foreach (var ch in s)
            {
                if (ch == ']')
                {
                    List<string> templist = new List<string>();
                    while (stack.Count > 0 && stack.Peek() != "[")
                    {
                        templist.Insert(0, stack.Pop());
                    }
                    stack.Pop(); // Remove '['

                    var stringBuilder = new StringBuilder();
                    while (stack.Count > 0 && int.TryParse(stack.Peek(), out int num))
                    {
                        stringBuilder.Insert(0, stack.Pop());
                    }

                    var repeatedInt = int.Parse(stringBuilder.ToString());
                    for (int i = 0; i < repeatedInt; i++)
                    {
                        stack.Push(string.Join("", templist));
                    }
                }
                else
                {
                    stack.Push(ch.ToString());   // 全部都轉 string 好處理
                }
            }

            return string.Join("", stack.Reverse());
        }
    }
}
