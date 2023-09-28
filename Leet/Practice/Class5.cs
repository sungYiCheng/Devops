using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public partial class Solution
    {
        public int designerPdfViewer(List<int> h, string word)
        {
            char[] array = word.ToCharArray();
            int Anum = Convert.ToInt32('A');

            int max = int.MinValue;
            foreach (char ch in array)
            {
                int chNum = Convert.ToInt32(ch);
                int dis = chNum - Anum;

                max = Math.Max(max, h[dis]);
            }

            return max * array.Length;

        }
    }


}
