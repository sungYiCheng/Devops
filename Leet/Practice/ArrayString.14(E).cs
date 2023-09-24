using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /*
	 * 
	 * 14. Longest Common Prefix
Solved
Easy
Topics
Companies
Write a function to find the longest common prefix string amongst an array of strings.

If there is no common prefix, return an empty string "".

 

Example 1:

Input: strs = ["flower","flow","flight"]
Output: "fl"
Example 2:

Input: strs = ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.
 

Constraints:

1 <= strs.length <= 200
0 <= strs[i].length <= 200
strs[i] consists of only lowercase English letters.
	 * 
	 * 
	*/

    public partial class Solution
    {

        public string LongestCommonPrefix(string[] strs)
        {
            List<char[]> list = new List<char[]>();

            for (int i = 0; i < strs.Length; i++)
            {
                char[] array = strs[i].ToCharArray();

                list.Add(array);
            }

            List<char> ans = Get(list);
            char[] final = (list.Count == 1) ? list[0] : ans.ToArray();

            return new string(final);
        }

        public List<char> Get(List<char[]> list)
        {
            List<char> ans = new List<char>();
            char[] target = list[0];
            for (int j = 0; j < target.Length; j++)
            {
                char word = target[j];

                bool check = false;
                for (int k = 1; k < list.Count; k++)
                {
                    if ((j < list[k].Length) && (list[k][j] == word))
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;
                        break;
                    }
                }

                if (check)
                {
                    ans.Add(word);
                }
                else
                {
                    break;
                }
            }

            return ans;
        }
    }
}
