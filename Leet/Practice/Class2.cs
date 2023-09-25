using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public partial class Solution
    {
        /*
         * 
         * 1071. Greatest Common Divisor of Strings
Attempted
Easy
Topics
Companies
Hint
For two strings s and t, we say "t divides s" if and only if s = t + ... + t (i.e., t is concatenated with itself one or more times).

Given two strings str1 and str2, return the largest string x such that x divides both str1 and str2.

 

Example 1:

Input: str1 = "ABCABC", str2 = "ABC"
Output: "ABC"
Example 2:

Input: str1 = "ABABAB", str2 = "ABAB"
Output: "AB"
Example 3:

Input: str1 = "LEET", str2 = "CODE"
Output: ""
 

Constraints:

1 <= str1.length, str2.length <= 1000
str1 and str2 consist of English uppercase letters.
         * 
         * 
         */


        public string GcdOfStrings(string str1, string str2)
        {
            string longStr = str1.Length > str2.Length ? str1 : str2;
            string shortStr = longStr == str1 ? str2 : str1;

            List<char> str2Array = str2.ToCharArray().ToList();
            StringBuilder check = new StringBuilder();

            string ans = string.Empty;
            for (int i = 0; i < shortStr.Length; i++) 
            {
                check.Append(shortStr[i]);

                string[] subStrArray = longStr.Split(check.ToString());

                int subStrCount = subStrArray.Where(x => !string.IsNullOrEmpty(x)).ToArray().Length;
                if (subStrCount == 0)
                {
                    ans = check.ToString();
                }
            }


            return ans;
        }
    }
}
