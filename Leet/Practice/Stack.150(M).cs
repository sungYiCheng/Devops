using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	/*
	 * 150. Evaluate Reverse Polish Notation
Solved
Medium
Topics
Companies
You are given an array of strings tokens that represents an arithmetic expression in a Reverse Polish Notation.

Evaluate the expression. Return an integer that represents the value of the expression.

Note that:

The valid operators are '+', '-', '*', and '/'.
Each operand may be an integer or another expression.
The division between two integers always truncates toward zero.
There will not be any division by zero.
The input represents a valid arithmetic expression in a reverse polish notation.
The answer and all the intermediate calculations can be represented in a 32-bit integer.
 

Example 1:

Input: tokens = ["2","1","+","3","*"]
Output: 9
Explanation: ((2 + 1) * 3) = 9
Example 2:

Input: tokens = ["4","13","5","/","+"]
Output: 6
Explanation: (4 + (13 / 5)) = 6
Example 3:

Input: tokens = ["10","6","9","3","+","-11","*","/","*","17","+","5","+"]
Output: 22
Explanation: ((10 * (6 / ((9 + 3) * -11))) + 17) + 5
= ((10 * (6 / (12 * -11))) + 17) + 5
= ((10 * (6 / -132)) + 17) + 5
= ((10 * 0) + 17) + 5
= (0 + 17) + 5
= 17 + 5
= 22
 

Constraints:

1 <= tokens.length <= 104
tokens[i] is either an operator: "+", "-", "*", or "/", or an integer in the range [-200, 200].
	 */


	public partial class Solution
	{
		public int EvalRPN(string[] tokens)
		{
			List<string> mathList = new List<string> { "+", "-", "*", "/" };

			Stack<int> nums = new Stack<int>();
			for (int i = 0; i < tokens.Length; ++i)
			{
				if (!mathList.Contains(tokens[i]))
				{
					nums.Push(Convert.ToInt32(tokens[i]));
				}
				else
				{
					int num1 = nums.Pop();
					int num2 = nums.Pop();

					int numNew = Cal(tokens[i], num1, num2);
					nums.Push(numNew);
				}
			}

			return nums.Pop();
		}

		public int Cal(string math, int num1, int num2)
		{
			switch (math)
			{
				case "+":
					return num2 + num1;
				case "-":
					return num2 - num1;
				case "*":
					return num2 * num1;
				case "/":
					return num2 / num1;
				default:
					return 0;
			}
		}
	}
}
