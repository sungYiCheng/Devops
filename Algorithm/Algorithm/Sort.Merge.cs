using System.Collections.Generic;

namespace Algorithm
{
	public static partial class Sort
	{
        /*
         * 將陣列對半拆分至剩一個元素 ( Divide，並使用到 Recursive 的概念 )
            針對相鄰兩個陣列做完比較後，完成排序與合併 ( Conquer )
         * 
         * 時間複雜度 = 分割步驟數 + 合併步驟數

            分割：分割含有 n 個資料需要 n-1 次，O(n)。
            合併：
    
            (以最後一次的合併來看，左右兩邊各自比對，把最小的丟到新的list中，值到某一方結束，就可以把另外一方整個在丟進去，因為都以排序過)
            在合併兩個已經排序好的小陣列時，我們每次都只需要比較兩個陣列的第一個數字，把比較小的依序丟到新的陣列中，
            再重新比較兩個小陣列的第一個數字。觀察上面的結果，要合併 n 個數字時，我們剛好也只需要 n 個步驟 (最差的情況就是全部都比對過一次，才加入了新的list)。

            那在合併排序法中，我們總共需要進行幾回合這樣的合併呢？
            假設 7 個小陣列合併成 4 個，再從 4 個合併成 2 個，最後合併成 1 個，
            因為每一回合的合併，都可以讓下一回合需要合併的陣列減少一半，這樣的特性表示總共需要合併的回合數會是以 2 為底的 log n 次。

            每回合的合併需要花：O(n)
            總共需要回合數：O(log n)

            分割 + 合併 找出最終複雜度    =>   (n-1) + nlogn =  O(nlogn)

            時間複雜度為: O(nlogn)

            Steable (倆倆合併時，不會改變順序)
         */

        public static List<int> MergeSort(List<int> list)
        {
            return SortAction(list);
        }

        private static List<int> SortAction(List<int> list)
        {
            if (list.Count < 2)
			{
                return list;
            }

            List<int> left = list.GetRange(0, list.Count / 2);
            List<int> right = list.GetRange(list.Count / 2, list.Count - (list.Count / 2));

            return Merge(SortAction(left), SortAction(right));
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>(left.Count + right.Count);

            result.AddRange(left);
            result.AddRange(right);
            result.Sort();

            return result;
        }
    }
}


