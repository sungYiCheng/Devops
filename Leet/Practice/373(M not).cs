using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public partial class Solution
	{
		public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
		{
			Dictionary<int, List<IList<int>>> dic = new Dictionary<int, List<IList<int>>>();

			for (int i = 0; i < nums1.Length; i++)
			{
				int minSum = 0;

				for (int j = 0; j < nums2.Length; j++)
				{
					int sum = nums1[i] + nums2[j];
					List<int> array = new List<int> { nums1[i], nums2[j] };

					if (!dic.ContainsKey(sum))
					{
						dic.Add(sum, new List<IList<int>>());
					}

					dic[sum].Add(array);
				}
			}

			List<int> sort = dic.OrderBy(x => x.Key).Select(x => x.Key).ToList();

			IList<IList<int>> ans = new List<IList<int>>();
			foreach (int x in sort)
			{
				for (int i = 0; i < dic[x].Count; i++)
				{
					ans.Add(dic[x][i]);

					if (ans.Count >= k)
					{
						return ans;
					}
				}
			}

			return ans;
		}




	}
}
