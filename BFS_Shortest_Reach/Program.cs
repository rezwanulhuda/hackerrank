using System;
using System.Collections.Generic;
using System.IO;

namespace BFS_Shortest_Reach
{
    class Solution
	{
        private interface ILineReader
        {
            string ReadLine();
        }

        private class FileLineReader : ILineReader
        {
            
            string[] lines;
            int currentLine = 0;
            public FileLineReader(string fileName)
            {
                lines = File.ReadAllLines(fileName);
            }

            public string ReadLine()
            {
                string s = lines[currentLine];
                currentLine++;
                return s;
            }
        }

        private class ConsoleLineReader : ILineReader
        {
            public string ReadLine()
            {
                return Console.ReadLine();
            }
        }


        private class Queue
        {
            Dictionary<int, List<int>> items = new Dictionary<int, List<int>>();

            public void Add(int iteration, int item)
            {

                if (!items.ContainsKey(iteration))
                {
                    items.Add(iteration, new List<int>() { item });
                } else
                {
                    items[iteration].Add(item);
                }
            }

            public int GetNext(int iteration)
            {
                if (items.ContainsKey(iteration))
                {
                    if (items[iteration].Count > 0)
                    {
                        int r = items[iteration][0];
                        items[iteration].RemoveAt(0);
                        return r;
                    }
                }
                
                return 0;
            }

        }

        public static void Main(string[] args)
		{
            ILineReader reader;

            if (args.Length > 0)
            {
                reader = new FileLineReader(args[0]);
            } else
            {
                reader = new ConsoleLineReader();
            }


            int testCases = int.Parse(reader.ReadLine());

            List<string> result = new List<string>();
			while (testCases > 0)
			{
				testCases--;


				string[] nodesNPaths = reader.ReadLine().Split(' ');

				int nodes = int.Parse(nodesNPaths[0]);
				int[,] graph = new int[nodes + 1, nodes + 1];
				int paths = int.Parse(nodesNPaths[1]);
				while (paths > 0)
				{
					paths--;
					string[] path = reader.ReadLine().Split(' ');
					int n1 = int.Parse(path[0]);
					int n2 = int.Parse(path[1]);
					graph[n1, n2] = 6;
					graph[n2, n1] = 6;
				}

				int start = int.Parse(reader.ReadLine());

                int[] visited = new int[nodes + 1];
				int[] distance = new int[nodes + 1];
                Queue q = new Queue();
                                
                int iteration = 1;

                q.Add(iteration, start);

                int currentItem = 0;
                do
                {
                    currentItem = q.GetNext(iteration);
                    if (currentItem == 0)
                    {
                        iteration++;
                        currentItem = q.GetNext(iteration);
                        if (currentItem == 0) break;
                    }
                    if (visited[currentItem] == 1) continue;

                    for (int x = 1; x < nodes + 1; ++x)
                    {                        
                        if (x == currentItem) continue;
                        if (visited[x] == 1) continue;
                        if (graph[currentItem, x] != 0)
                        {
                            q.Add(iteration + 1, x);
                            if (distance[x] == 0)
                            {
                                distance[x] = iteration * 6;
                            }
                            else if (distance[x] > iteration * 6)
                            {
                                distance[x] = iteration * 6;
                            }
                        }
                    }
                    visited[currentItem] = 1;
                    

                }
                while (currentItem > 0);

                string output = String.Empty;
                for(int x = 1; x < distance.Length; ++x)
                {
                    if (x == start) continue;
                    if (x > 1)
                    {
                        output += " ";
                    }

                    if (distance[x] > 0)
                        output += distance[x].ToString();
                    else
                        output += "-1";
                }
                result.Add(output.Trim());
            }

            foreach(var s in result)
            {
                Console.WriteLine(s);
            }
            //Console.ReadLine();
        }
	}
}
