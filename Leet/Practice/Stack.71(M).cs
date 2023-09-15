using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /*71. Simplify Path
Solved
Medium
Topics
Companies
Given a string path, which is an absolute path (starting with a slash '/') to a file or directory in a Unix-style file system, convert it to the simplified canonical path.

In a Unix-style file system, a period '.' refers to the current directory, a double period '..' refers to the directory up a level, and any multiple consecutive slashes (i.e. '//') are treated as a single slash '/'. For this problem, any other format of periods such as '...' are treated as file/directory names.

The canonical path should have the following format:

The path starts with a single slash '/'.
Any two directories are separated by a single slash '/'.
The path does not end with a trailing '/'.
The path only contains the directories on the path from the root directory to the target file or directory (i.e., no period '.' or double period '..')
Return the simplified canonical path.

 

Example 1:

Input: path = "/home/"
Output: "/home"
Explanation: Note that there is no trailing slash after the last directory name.
Example 2:

Input: path = "/../"
Output: "/"
Explanation: Going one level up from the root directory is a no-op, as the root level is the highest level you can go.
Example 3:

Input: path = "/home//foo/"
Output: "/home/foo"
Explanation: In the canonical path, multiple consecutive slashes are replaced by a single one.
 

Constraints:

1 <= path.length <= 3000
path consists of English letters, digits, period '.', slash '/' or '_'.
path is a valid absolute Unix path.
	 */

    public partial class Solution
    {
        public string SimplifyPath(string path)
        {
            string[] strArray = path.Split("/");

            Stack<string> ansStack = new Stack<string>();

            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i] == "..")
                {
                    if (ansStack.Count > 0)
                    {
                        ansStack.Pop();
                    }
                }
                // 用 "/" 切開後，重複的 "////..."會產生很多""，然後 "." 等於再原本資料夾下，這兩者都無需理會
                else if (!string.IsNullOrEmpty(strArray[i]) && string.Compare(".", strArray[i]) != 0)  
                {
                    ansStack.Push(strArray[i]);
                }
            }

            StringBuilder stringBuilder = new StringBuilder();

            if (ansStack.Count == 0)
            {
                stringBuilder.Append("/");
            }
            else
            {
                while (ansStack.Count > 0)
                {
                    string str = ansStack.Pop();
                    stringBuilder.Insert(0, str);
                    stringBuilder.Insert(0, "/");
                }
            }

            return stringBuilder.ToString();
        }
    }
}
