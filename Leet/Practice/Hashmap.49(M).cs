using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /*
     * 49. Group Anagrams
Solved
Medium
Topics
Companies
Given an array of strings strs, group the anagrams together. You can return the answer in any order.

An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

 

Example 1:

Input: strs = ["eat","tea","tan","ate","nat","bat"]
Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
Example 2:

Input: strs = [""]
Output: [[""]]
Example 3:

Input: strs = ["a"]
Output: [["a"]]
 

Constraints:

1 <= strs.length <= 104
0 <= strs[i].length <= 100
strs[i] consists of lowercase English letters.
     * 
     */

    public partial class Solution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {

            Dictionary<string, IList<string>> dic = new Dictionary<string, IList<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                // 把字串照字母順序排序
                string str = String.Concat(strs[i].OrderBy(c => c));

                if (!dic.ContainsKey(str))
                {
                    dic.Add(str, new List<string>());
                }

                dic[str].Add(strs[i]);
            }

            return dic.Values.ToList();
        }

    }
}
