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
         * 345. Reverse Vowels of a String
Solved
Easy
Topics
Companies
Given a string s, reverse only all the vowels in the string and return it.

The vowels are 'a', 'e', 'i', 'o', and 'u', and they can appear in both lower and upper cases, more than once.

 

Example 1:

Input: s = "hello"
Output: "holle"
Example 2:

Input: s = "leetcode"
Output: "leotcede"
 

Constraints:

1 <= s.length <= 3 * 105
s consist of printable ASCII characters.
         * 
         * 
         */



        public string ReverseVowels(string s)
        {
            List<char> vowelList = new List<char>(5) {Convert.ToChar("a"), Convert.ToChar("e"), Convert.ToChar("i"), Convert.ToChar("o"), Convert.ToChar("u") };
            List<char> wordList = new List<char>();
            List<int> indexList = new List<int>();

            char[] chars = s.ToCharArray();


            for (int i = 0; i < chars.Length; i++) 
            { 
                if (vowelList.Contains(chars[i]))
                {
                    indexList.Add(i);
                    wordList.Add(chars[i]);
                }
            }

            wordList.Reverse();

            for (int j = 0;j < indexList.Count; j++) 
            {
                chars[indexList[j]] = wordList[j];
            }

            return new string(chars);
        }
    }
}
