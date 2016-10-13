using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Characters
{
    class Solution
    {
        class Distribution
        {
            public char Char { get; set; }
            public int Count { get; set; }
        }

        static void Main(string[] args)
        {
            Console.ReadLine();
            var s = Console.ReadLine();

            List<Distribution> dist = new List<Distribution>();
            //int[] count = new int[26];
            
            foreach(char c in s.Distinct())
            {
                dist.Add(new Distribution() { Char = c, Count = s.Count(p => p == c) });
            }

            dist.Sort((p, q) => p.Count - q.Count);

            
            for(int x = 0; x < dist.Count - 1; ++x)
            {
                if ((dist[x].Count - dist[x + 1].Count) != 1)
                {
                    s = s.Replace(dist[x].Char.ToString(), String.Empty);
                    dist.Remove(dist[x]);
                    x--;
                }
            }

            
            if (dist.Count == 2)
            {

            }


            
        }
    }
}
