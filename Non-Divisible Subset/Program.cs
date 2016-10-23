using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Non_Divisible_Subset
{
    class Program
    {
        static void Main(string[] args)
        {
            var line1 = Console.ReadLine().Split(' ');
            var n = int.Parse(line1[0]);
            var k = int.Parse(line1[1]);

            var line2 = Console.ReadLine().Split(' ');
            int[] a = new int[n];


            for(int i = 0; i < n; ++i)
            {
                a[i] = int.Parse(line2[i]);
            }

            List<int> sums = new List<int>();

            for(int x = 0; x < n - 1; ++x)
            {
                for(int y = x + 1; y < n; ++y)
                {
                    sums.Add(a[x] + a[y]);
                    for (int z = 0; z < x - 1; ++z)
                    {
                        sums.Add(a[x] + a[z]);
                    }
                }                
            }





        }
    }
}
