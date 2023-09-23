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
6. Zigzag Conversion
Solved
Medium
Topics
Companies
The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

P   A   H   N
A P L S I I G
Y   I   R
And then read line by line: "PAHNAPLSIIGYIR"

Write the code that will take a string and make this conversion given a number of rows:

string convert(string s, int numRows);
 

Example 1:

Input: s = "PAYPALISHIRING", numRows = 3
Output: "PAHNAPLSIIGYIR"
Example 2:

Input: s = "PAYPALISHIRING", numRows = 4
Output: "PINALSIGYAHRPI"
Explanation:
P     I    N
A   L S  I G
Y A   H R
P     I
Example 3:

Input: s = "A", numRows = 1
Output: "A"
 
Constraints:

1 <= s.length <= 1000
s consists of English letters (lower-case and upper-case), ',' and '.'.
1 <= numRows <= 1000

	*/

    public partial class Solution
    {
        public string LeetConvert(string s, int numRows)
        {
            Dictionary<int, List<char>> dic = new Dictionary<int, List<char>>();

            for (int i = 0; i < numRows; i++)
            {
                dic.Add(i, new List<char>());
            }

            if (dic.Count <= 1)
            {
                return s;
            }

            char[] sArr = s.ToCharArray();

            int num = (2 * numRows) - 2;  // 可以推算 一次循環的 字母數量 公式
            for (int i = 0; i < sArr.Length; i++)
            {
                int check = i % num;

                if (check < numRows)
                {
                    dic[check].Add(sArr[i]);        // 在 numRows 內的 都是 丟直線儲存
                }
                else
                {

                    int left = check - numRows;

                    //  ex: 用 numRows = 5 來作例子, (5 - 1) = 4 是第一排的最後index, 再減1 是 5 會從 index 3 開始, 6 就變到 index 2....
                    int index = (numRows - 1) - 1 - left;

                    dic[index].Add(sArr[i]);
                }
            }

            string ans = string.Empty;
            for (int i = 0; i < numRows; i++)
            {
                ans += new string(dic[i].ToArray());
            }

            return ans;
        }
    }
}
