using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
	class Program
	{
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 2, 3, 1, 6, 2, 9, 4, 1, 7 };
            int searchTarget = 7;

            // Check Sort
            // SortAction(list);

            // Check Sort
            SearchAction(list, searchTarget);

            Console.ReadLine();
        }

        private static void SortAction(List<int> list)
		{
            Console.WriteLine("排序前數列");
            Sort.Show(list);

            // 氣泡排序 (兩兩比較，前者較大就交換，讓大值一直往上，接著扣除排好的值後，在開始下一輪)
            // Sort.BubbleSort(list);

            // 選擇排序 (每次都找最小值，跟最前面交換，使最小值慢慢累積在前面，接著扣除排好的值後，在開始下一輪)
            // Sort.SelectSort(list);

            // 插入排序 (從第二值開始，一直往前比較，比前面小，就往前插，值到比前面大就停，在開始下一輪)
            // Sort.InsertionSort(list);

            // 快速排序 (每次取一個值當基準，其餘依序把比此值小的放左邊，比此值大的放右邊，然後再針對左右兩區塊重復動作，直到所有排序皆完成)
            // Sort.QuickSort(list);

            // 合併排序 (先不斷拆分到單一個單位，再兩兩相鄰合併+排序，依序重複上述動作，直到全部重組完成)
            List<int> sortedList = Sort.MergeSort(list);
            list = sortedList;

            Console.WriteLine("\r\n排序後數列");
            Sort.Show(list);
        }

        private static void SearchAction(List<int> list, int target)
        {
            Console.WriteLine("搜尋數列");
            Sort.Show(list);
            Console.WriteLine($"目標: {target}");

            // 線性搜尋 (一個一個找，找到為止)
            //int index = Search.LinearSearch(list, target);

            // 二元搜尋 (只能搜尋已排序好的，切半找，剛好就找到，比較小就往左半邊群，比較大就往右半邊群，再重複切半搜尋，直到找到)
            //int index = Search.BinarySearch(list, target);

            // 指數搜尋 (只能搜尋已排序好的，先用2的指數0 index 開始找，相同就找到，比較小就增加指數，比較大，則已本次指數和上次指數為範圍，進行二元搜尋)
            // int index = Search.ExponentialSearch(list, target);

            // 內插搜尋 (用內插法找出每一次的檢查值, 比目標小，就把上界改成檢查值的資訊，再重複操作直到找到為止)
            int index = Search.InterpolationSearch(list, target);

            Sort.Show(target, index);
        }
    }
}
