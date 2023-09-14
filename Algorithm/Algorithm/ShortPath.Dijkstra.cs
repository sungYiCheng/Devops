using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static partial class ShortPath
	{
		private static int MinimumDistance(List<int> distance, List<bool> shortestPathSet, int totalNode)
		{
			int min = int.MaxValue;
			int minIndex = -1;

			for (int i = 0; i < totalNode; ++i)
			{
				if (shortestPathSet[i] == false && distance[i] <= min)
				{
					min = distance[i];
					minIndex = i;
				}
			}

			return minIndex;
		}

		public static void Dijkstra(List<int[]> graph, int source, int totalNode)
		{
			List<int> shortDistance = new List<int>();
			List<bool> alredaySetshortestPath = new List<bool>();

			// 初始化
			for (int i = 0; i < totalNode; ++i)
			{
				shortDistance.Add(int.MaxValue);
				alredaySetshortestPath.Add(false);
			}

			shortDistance[source] = 0;

			// 這邊只是幾個node，需要檢查幾次，順序裡面才決定
			for (int j = 0; j < totalNode - 1; j++)
			{
				// 開始每一個節點檢查，找出目前還沒被檢查過，且source -> checkNode 最短的
				int checkNode = MinimumDistance(shortDistance, alredaySetshortestPath, totalNode);

				alredaySetshortestPath[checkNode] = true;

				for (int node = 0; node < totalNode; node++)
				{			
					// 開始檢查到每一個點，是否要更新最小路徑
					if ((!alredaySetshortestPath[node]) && (graph[checkNode][node] > 0) && (shortDistance[checkNode] != int.MaxValue) && (shortDistance[node] > shortDistance[checkNode] + graph[checkNode][node]))
					{
						shortDistance[node] = shortDistance[checkNode] + graph[checkNode][node];
					}
				}
			}

			for (int i = 0; i < totalNode; ++i)
			{
				Console.WriteLine($"from:{source} to node:{i}, shortPath: {shortDistance[i]}");
			}
		}
	}
}


