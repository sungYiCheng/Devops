using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /*
     * 
     * 1657. Determine if Two Strings Are Close
Attempted
Medium
Topics
Companies
Hint
Two strings are considered close if you can attain one from the other using the following operations:

Operation 1: Swap any two existing characters.
For example, abcde -> aecdb
Operation 2: Transform every occurrence of one existing character into another existing character, and do the same with the other character.
For example, aacabb -> bbcbaa (all a's turn into b's, and all b's turn into a's)
You can use the operations on either string as many times as necessary.

Given two strings, word1 and word2, return true if word1 and word2 are close, and false otherwise.

 

Example 1:

Input: word1 = "abc", word2 = "bca"
Output: true
Explanation: You can attain word2 from word1 in 2 operations.
Apply Operation 1: "abc" -> "acb"
Apply Operation 1: "acb" -> "bca"
Example 2:

Input: word1 = "a", word2 = "aa"
Output: false
Explanation: It is impossible to attain word2 from word1, or vice versa, in any number of operations.
Example 3:

Input: word1 = "cabbba", word2 = "abbccc"
Output: true
Explanation: You can attain word2 from word1 in 3 operations.
Apply Operation 1: "cabbba" -> "caabbb"
Apply Operation 2: "caabbb" -> "baaccc"
Apply Operation 2: "baaccc" -> "abbccc"
 

Constraints:

1 <= word1.length, word2.length <= 105
word1 and word2 contain only lowercase English letters.
     * 
     */

    public partial class Solution
    {
        public bool CloseStrings(string word1, string word2)
        {
            if (word1.Length != word2.Length)
            {
                return false;
            }

            char[] charArray_1 = word1.ToCharArray();
            char[] charArray_2 = word2.ToCharArray();

            Dictionary<char, int> dic_1 = new Dictionary<char, int>();
            Dictionary<char, int> dic_2 = new Dictionary<char, int>();

            for (int i = 0; i < charArray_1.Length; i++) 
            { 
                if (!dic_1.ContainsKey(charArray_1[i]))
                {
                    dic_1.Add(charArray_1[i], 1);
                }
                else
                {
                    dic_1[charArray_1[i]]++;
                }

                if (!dic_2.ContainsKey(charArray_2[i]))
                {
                    dic_2.Add(charArray_2[i], 1);
                }
                else
                {
                    dic_2[charArray_2[i]]++;
                }
            }

            // 重要:  要多檢查這裡來避免像  "uau", "ssx" 這樣的範例，題目是可以位置互換 和 腳色對換，
            // 但一定要是"目前已經出現的字"，這很關鍵，代表雙方只有有任一個對方沒有的字母，就無法達成轉換
            List<char> key_1 = dic_1.Keys.ToList();
            List<char> key_2 = dic_2.Keys.ToList();

            foreach (char key in key_1)
			{
                if (!key_2.Contains(key))
				{
                    return false;
				}
			}

            //通過 字母 總類測試後，就可以來檢驗 數量，基本上 只有排序完，雙方跑出一樣的數量list，就可以互換成功了
            List<int> value_1 = dic_1.Values.ToList();
            value_1.Sort();

            List<int> value_2 = dic_2.Values.ToList();
            value_2.Sort();

            bool isSame = string.Join(",", value_1) == string.Join(",", value_2);

            return isSame;
        }
    }
}
