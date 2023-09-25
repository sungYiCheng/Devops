using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
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

            List<int> value_1 = dic_1.Values.ToList();
            value_1.Sort();

            List<int> value_2 = dic_2.Values.ToList();
            value_2.Sort();

            bool isSame = string.Join(",", value_1) == string.Join(",", value_2);

            return isSame;
        }
    }
}
