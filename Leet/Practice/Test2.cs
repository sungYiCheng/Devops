using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public partial class Solution
	{
		public int Test2(List<List<string>> source)
		{
			Dictionary<string, List<int>> prevDic = new Dictionary<string, List<int>>();
			Dictionary<string, List<int>> nowDic = new Dictionary<string, List<int>>();

			bool left = true;
			bool up = true;
			string prev = string.Empty;
			int count = 0;

			foreach (List<string> subStr in source)
			{
				for (int i = 0; i < subStr.Count; i++)
				{
					if (prevDic.Count == 0)
					{
						if (prev != subStr[i])
						{
							count++;
						}

						if (!nowDic.ContainsKey(subStr[i]))
						{
							nowDic.Add(subStr[i], new List<int>());
						}

						nowDic[subStr[i]].Add(i);
					}
					else
					{
						// check left
						if (prev != subStr[i])
						{
							left = true;
						}

						// check up
						if (prevDic.TryGetValue(subStr[i], out List<int> list))
						{
							if (!list.Contains(i))
							{
								up = false;
							}
						}

						if (!nowDic.ContainsKey(subStr[i]))
						{
							nowDic.Add(subStr[i], new List<int>());
						}

						nowDic[subStr[i]].Add(i);

						if (left && up)
						{
							count++;
						}
					}

					prev = subStr[i];
				}

				prev = string.Empty;
				prevDic = nowDic.ToDictionary(data => data.Key, data => data.Value);
				nowDic.Clear();
				left = true;
				up = true;
			}

			return count;
		}
	}
}
