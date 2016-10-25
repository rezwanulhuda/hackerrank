using System;

namespace BFS_Shortest_Reach
{
	class Solution
	{
		public static void Main(string[] args)
		{
			int testCases = int.Parse(Console.ReadLine());

			while (testCases > 0)
			{
				testCases--;

				string[] nodesNPaths = Console.ReadLine().Split(' ');

				int nodes = int.Parse(nodesNPaths[0]);
				int[,] graph = new int[nodes + 1, nodes + 1];
				int paths = int.Parse(nodesNPaths[1]);
				while (paths > 0)
				{
					paths--;
					string[] path = Console.ReadLine().Split(' ');
					int n1 = int.Parse(path[0]);
					int n2 = int.Parse(path[1]);
					graph[n1, n2] = 6;
					graph[n2, n1] = 6;
				}

				int start = int.Parse(Console.ReadLine());

				int[] distance = new int[nodes + 1];


				                      
			}
			Console.WriteLine("Hello World!");
		}
	}
}
