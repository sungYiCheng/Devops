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
     */


    public partial class Solution
    {
        public bool IsPalindrome(string s)
        {
            char[] array = s.ToCharArray();
            List<char> resetArray = new List<char>();

            for (int i = 0; i < array.Length; i++)
            {
                // 全轉小寫，然後用ASCII
                char low = Char.ToLower(array[i]);
                int A = Convert.ToInt32(low);

                // 去除數字 和 字母以外的字
                if (A >= Convert.ToInt32('0') && A <= Convert.ToInt32('9'))
                {
                    resetArray.Add(low);
                }
                else if (A >= Convert.ToInt32('a') && A <= Convert.ToInt32('z'))
                {
                    resetArray.Add(low);
                }
            }

            // 開始頭尾往內比對
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
