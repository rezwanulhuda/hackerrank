using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare_the_Triplets
{
    class Solution
    {
        static void Main(string[] args)
        {
            List<int> aliceScore = new List<int>() ;
            List<int> bobScore = new List<int>();
            var input = Console.ReadLine().Split(' ');
            //aliceScore = new int[input.Length];
            foreach(var num in input)
            {
                aliceScore.Add(int.Parse(num));
            }

            input = Console.ReadLine().Split(' ');

            foreach (var num in input)
            {
                bobScore.Add(int.Parse(num));
            }

            int alice = 0;
            int bob = 0;
            for(int x = 0, y = 0; x < aliceScore.Count; ++x, ++y)
            {
                if (aliceScore[x] > bobScore[x])
                {
                    alice++; continue;
                }
                if (bobScore[x] > aliceScore[x])
                {
                    bob++; continue;
                }                    
            }

            Console.WriteLine(String.Format("{0} {1}", alice, bob));

            //Console.ReadLine();



        }
    }
}
