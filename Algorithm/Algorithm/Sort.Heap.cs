﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static partial class Sort
    {
        public static void HeapSort(int[] arr)
        {
            int temp = 0;

            // 將無序序列構建成一個Heap, 根據升序降序需求選擇 Max Heap 或 Min Heap
            // arr.length / 2 - 1 => 從下至上 由左至右 找出非葉子節點
            for (int i = arr.Length / 2 - 1; i >= 0; i--)
            {
                // [4, 6, 8, 5, 9] => [4, 9, 8, 5, 6] => [9, 6, 8, 5, 4]
                AdjustHeap(arr, i, arr.Length);
            }

            // 此時 [9, 6, 8, 5, 4]
            // 將堆頂元素與末尾元素交換, 將最大元素移到陣列末端 [9, 6, 8, 5, 4] => [4, 6, 8, 5, 9] 
            // 重新調整結構, 使其滿足堆定義, 然後繼續交換堆頂元素與當前末尾元素, 反覆執行調整+交換, 直到整個序列有序
            for (int j = arr.Length - 1; j > 0; j--)
            {
                // 交換
                temp = arr[j];
                arr[j] = arr[0];
                arr[0] = temp;
                AdjustHeap(arr, 0, j);
            }

            Console.WriteLine(string.Join(",", arr));
        }
        /**
         * 功能：完成 將 i 對應的非葉子節點的子樹調整成 Max Heap
         * 舉例：int arr[] = {4, 6, 8, 5, 9} , i = 1 => adjustHeap 得到 {4, 9, 8, 5, 6}
         * 如果我們再次調用 adjustHeap 傳入的是 i = 1 => 得到 {4, 9, 8, 5, 6} => {9, 6, 8, 5, 4}
         * @param arr 待調整的陣列
         * @param i 表示非葉子節點在陣列中的索引
         * @param length 表示對多少個元素進行調整, length是在逐漸的減少
         */
        // 將一個陣列(二元樹), 調整成一個 Max Heap
        public static void AdjustHeap(int[] arr, int i, int length)
        {
            int temp = arr[i]; // 先取出當前元素的值, 保存在臨時變數
                               // 開始調整
                               // int k = i * 2 + 1 => i 的左子節點
                               // k = k * 2 + 1 => 下次再調的話就是下面的左子節點
            for (int k = i * 2 + 1; k < length; k = k * 2 + 1)
            {
                if (k + 1 < length && arr[k] < arr[k + 1])
                { // 左子節點小於右子節點
                    k++; // k 指向右子節點(因為要找到最大值)
                }
                if (arr[k] > temp)
                { // 如果子節點大於父節點
                    arr[i] = arr[k]; // 把較大的值賦給當前值
                    i = k; // i 指向 k 繼續循環比較
                }
                else
                {
                    break;
                }
            }
            arr[i] = temp; // 將 temp 值放到調整後的位置
        }
    }

}
