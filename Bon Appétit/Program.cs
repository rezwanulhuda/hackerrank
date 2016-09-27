using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bon_Appétit
{
    class Solution
    {
        static void Main(String[] args)
        {
            var line = Console.ReadLine();
            var inputs = line.Split(' ');
            var items = int.Parse(inputs[0]);
            var skipped = int.Parse(inputs[1]);

            var pricesStr = Console.ReadLine().Split(' ');
            int[] prices = new int[pricesStr.Length];
            for(int x = 0; x < pricesStr.Length; ++x)
            {
                prices[x] = int.Parse(pricesStr[x]);
            }
            var charged = int.Parse(Console.ReadLine());

            int actual = 0;
            for(int x = 0; x < prices.Length; ++x)
            {
                if (x != skipped)
                {
                    actual += prices[x];
                }
            }

            actual = actual / 2;

            if (charged == actual)
            {
                Console.WriteLine("Bon Appetit");
            }
            else
            {
                Console.WriteLine(charged - actual);
            }

            //Console.ReadLine();
        }
    }
}
