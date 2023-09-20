using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static partial class Sort
    {

        static int Fibonacci(int num)
        {
            if (num <= 2)
			{
                return 1;
            }
            else
			{
                return Fibonacci(num - 1) + Fibonacci(num - 2);
            }
        }
    }
}
