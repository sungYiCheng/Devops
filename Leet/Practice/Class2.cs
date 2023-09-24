using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public partial class Solution
    {
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
