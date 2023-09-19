using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static partial class Sort
	{
        /*
         * 總共比較了 1+2+3+…+(n-1)
         * 
            也就是 n*(n-1)/2
            時間複雜度會忽略係數，所以為 

            O(n^2)
         * 
         * Steable (相同的 也會 用相同的順序插入，不會改變)
         * 
         */


        public static void InsertionSort(List<int> list)
        {
            int check;

            // 注意從1開始，目的是可以檢查 0 看要插入前面還是後面
            for (int i = 1; i < list.Count; i++)
            {
                check = list[i];

                // 每次都檢查 check 之前到 0，看要把check插入在哪邊
                for (int j = i - 1; j >= 0; j--)
                {
                    // 比check大，把比較的值往前移一格 (先把他複製到前一格 )
                    if (list[j] > check)
                    {
                        list[j + 1] = list[j];

                        // 假設 比到最後前面都比 check大，那最後0就放check
                        if (j == 0)
                        {
                            list[0] = check;
                            break;
                        }
                    }
                    else
                    {
                        //  假設目前比較的值 list[j] 比 check小，代表check要插在他之前，因此 list[j + 1] = check
                        list[j + 1] = check;
                        break;
                    }
                }
            }
        }
    }
}


