using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static partial class Sort
	{
        /*
         * 先選一個 基準值  通常會選第一個元素(index 0)
         * 準備兩個 index 標籤，一個代表 left index(1)  一個代表 right index(n -1) 開始
         * left 和 right 都和 基準值做比對，left找比基準值大的，right找比基準值小的，然後兩者交換
         * 其用意在於要把比基準值大的都丟到右邊，然後小的都丟左邊
         * 雙方一路前進比對交換後，當出現  left >= right 時，代表這一輪比對完成
         * 
         * 注意，此時因為演算法的推進 left 和 right 是交錯的，right會指向原本left的值(比基準值小)，left會指向原本right的值(比基準值大)
         * 
         * 因此這邊要跟基準值交換的，會是 right!!
         * 然後把基準值和right交換，此時right會是比基準值小的數，交換後會讓 right 丟到左邊群組，基準值會會到中間
         * 如此一來就會完成  [比基準值小的一坨] 基準值 [比基準值大的一坨]
         * 
         * 然後在把 [比基準值小的一坨] 和 [比基準值大的一坨] 用上述方法反覆排序，最終就可以完成
         * 
         * 時間複雜度:
         * Worst case:
         * 最差的分割序列狀況發生在挑選的 pivot 總是最大或最小值，這種情形好發於已排序或接近排序完成的資料上
         * 使每一次排序，都只排好其中一格，也就是必須歷經 n + (n-1) + (n-2)......+1 這麼多次回合的排序
         * 根據梯形公式 =>  (n + 1) * n / 2 = (n + n^2) / 2 => O(n^2)
         * 
         * 每一次選出基準值來分割 也會耗費 O(n)，然後必須要執行 n-i次 (i只是個代表數，表示共會經過 n - i 次分割)
         * 因此會產生 (n-i) * n => O(n^2)
         * 
         * 因此 (n-i) * n  + (n + n^2) / 2 => O(n^2) 
         * 
         * best case:
         * 最佳情況則發生在每次 pivot 都可以順利選到序列的中位數（median），
         * 如此一來，每次遞迴分割的序列長度都會減半（n/2），呼叫遞迴的次數總共需要 2logn (左右各一次)，遞迴就會呼叫完成 (長度為1)
         * 而每次分割同樣有 O(n)的複雜度，因此最佳情況為：O(n⋅2log2n)=O(nlogn)
         * 
         * (簡單來想，就是每次都選到中間，把左右都排好，可以把比較次數減少到只需要 O(nlogn))
         * 
         * 
         * Unsteabel ( 跟基準值 交換時，可能會把原本前面的 換到 後面去， ex:  5 3 3 4 3 8 9 10 11)
         * 
         * 
         */

        public static void QuickSort(List<int> list)
        {
            QuickSortAction(list, 0, list.Count - 1);
        }

        public static void QuickSortAction(List<int> list, int low, int high)
        {
            if (low >= high)
			{
                return;
            }

            int check = list[low];
            int left = low + 1;
            int right = high;

            while (true)
            {
                // 從後方找 比 目標小的
                while (list[right] > check)
                {
                    right--;
                }

                // 從前方找 比 目標大的
                while (list[left] < check && left < right)
				{
                    left++;
                }

                // 一但 發生代表此輪和基準值(check)比對都完成
                if (left >= right)
				{
                    break;
                }

                Swap(list, left, right);

                // 交換完，記得要為下一次的比對目標，前進
                left++; 
                right--;
            }

            // right會指向原本left的值(比基準值小)，left會指向原本right的值(比基準值大)，目的是要把小的丟到左邊(和基準值交換)
            if (right != low)
			{
                Swap(list, low, right);
            }

            QuickSortAction(list, right + 1, high);
            QuickSortAction(list, low, right - 1);
        }
    }
}


