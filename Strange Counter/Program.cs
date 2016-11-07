using System;

namespace Strange_Counter
{
    class Solution
    {
        static long nthSum(int n)
        {
            long r = 2;
            long a = 3;

            return a * (long)((1 - Math.Pow(r, n)) / (1 - r));
        }

        static void Main(string[] args)
        {
            var t = long.Parse(Console.ReadLine());

            long result = 0;
            if (t <= 3)
            {
                result = 3 - t + 1;
            }
            else
            {
                var n = 2;
                while (t > nthSum(n))
                {
                    n++;
                }
                n--;
                var total = nthSum(n);

                var remaining = t - total;
                var nthCount = (long)(3 * Math.Pow(2, n));
                result = nthCount - remaining + 1;
            }

            
            Console.WriteLine(result);
            
            

            //Console.ReadLine();

        }
    }
}
