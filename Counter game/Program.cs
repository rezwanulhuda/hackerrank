using System;
using System.IO;

namespace Counter_game
{
    class Solution
    {
        static bool isPowerOfTwo(ulong x)
        {
            while (((x & 1) == 0) && x > 1) /* While x is even and > 1 */
                x >>= 1;
            return (x == 1);
        }

        static ulong nrOfBits(ulong x)
        {
            return (ulong) Math.Floor(Math.Log(x) / Math.Log(2)) + 1;
        }


        static void Main(string[] args)
        {
            
            string[] inputs = null;
            if (args.Length > 0)
            {
                inputs = File.ReadAllLines(args[0]);                
            }
            else
            {
                var t = int.Parse(Console.ReadLine());

                inputs = new string[t + 1];
                inputs[0] = t.ToString();
                for(int  x = 1; x <= t; ++x)
                {
                    inputs[x] = Console.ReadLine();
                }
                
            }
            
            string[] players = new string[] { "Louise", "Richard" };

            

            for(int x = 1; x < inputs.Length; ++x)
            {
                

                var n = ulong.Parse(inputs[x]);
                
                long counter = 1;
                while (n > 1)
                {
                    if (!isPowerOfTwo(n))
                    {
                        var bits = nrOfBits(n);
                        n = n - (ulong)Math.Pow(2, bits-1);
                    }
                    else
                    {
                        n = n / 2;
                    }

                    counter++;
                }

                Console.WriteLine(players[counter % 2]);
            }
            
            //Console.ReadLine();
        }
    }
}
