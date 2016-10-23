using System;
using System.Linq;

namespace Sock_Merchant
{
    class Solution
    {
        static void Main(string[] args)
        {
            Console.ReadLine();

            string[] sSocks = Console.ReadLine().Split(' ');
            int[] socks = new int[sSocks.Length];
            for(int i = 0; i < sSocks.Length; ++i)
            {
                socks[i] = int.Parse(sSocks[i]);
            }

            int count = 0;
            foreach(int s in socks.Distinct())
            {
                int colorCount = socks.Count(p => p == s);
                count += (int)colorCount / 2;
            }

            Console.WriteLine(count);
            //Console.ReadLine();
        }
    }
}
