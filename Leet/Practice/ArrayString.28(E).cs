using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /*
	 * 
	 * 
	 * 28. Find the Index of the First Occurrence in a String
Solved
Easy
Topics
Companies
Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

Example 1:

Input: haystack = "sadbutsad", needle = "sad"
Output: 0
Explanation: "sad" occurs at index 0 and 6.
The first occurrence is at index 0, so we return 0.
Example 2:

Input: haystack = "leetcode", needle = "leeto"
Output: -1
Explanation: "leeto" did not occur in "leetcode", so we return -1.
 

Constraints:

1 <= haystack.length, needle.length <= 104
haystack and needle consist of only lowercase English characters.
	*/


    public partial class Solution
    {
        public int StrStr(string haystack, string needle)
        {
            string[] array = haystack.Split(needle);

            if (array.Length <= 1)
			{
                return -1;
			}
            else
			{
                return array[0].Length;
            }
        }


        public int StrStr_v2(string haystack, string needle)
        {
            int getIndex = -1;
            char[] haystackArray = haystack.ToCharArray();
            char[] needleArray = needle.ToCharArray();

            if (string.IsNullOrEmpty(needle) || string.IsNullOrEmpty(haystack))
            {
                return string.IsNullOrEmpty(needle) ? 0 : string.IsNullOrEmpty(haystack) ? getIndex : 0;
            }
            else
            {
                if (haystack.Length >= needleArray.Length)
                {
                    for (int i = 0; i < haystackArray.Length; ++i)
                    {
                        if ((haystackArray[i] == needleArray[0]) && haystack.Length - i >= needleArray.Length)
                        {
                            string check = haystack.Substring(i, needleArray.Length);

                            if (string.Compare(check, needle) == 0)
                            {
                                getIndex = i;
                                break;
                            }
                        }
                    }
                }

                return getIndex;
            }
        }
    }
}
