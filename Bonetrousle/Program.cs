using System;
using System.Collections.Generic;
using System.Linq;


namespace Bonetrousle
{
    class Solution
    {
        static List<int[]> partitions = new List<int[]>();
        static void printArray(int[] p, int n)
        {
            int[] copied = new int[n];
            for(int i = 0; i < n; ++i)
            {
                copied[i] = p[i];
            }

            partitions.Add(copied);            
        }

        static void printAllUniqueParts(int n)
        {
            partitions.Clear();
            int[] p = new int[n]; // An array to store a partition
            int k = 0;  // Index of last element in a partition
            p[k] = n;  // Initialize first partition as number itself

            // This loop first prints current partition, then generates next
            // partition. The loop stops when the current partition has all 1s
            while (true)
            {
                // print current partition
                printArray(p, k + 1);

                // Generate next partition

                // Find the rightmost non-one value in p[]. Also, update the
                // rem_val so that we know how much value can be accommodated
                int rem_val = 0;
                while (k >= 0 && p[k] == 1)
                {
                    rem_val += p[k];
                    k--;
                }

                // if k < 0, all the values are 1 so there are no more partitions
                if (k < 0) return;

                // Decrease the p[k] found above and adjust the rem_val
                p[k]--;
                rem_val++;


                // If rem_val is more, then the sorted order is violeted.  Divide
                // rem_val in differnt values of size p[k] and copy these values at
                // different positions after p[k]
                while (rem_val > p[k])
                {
                    p[k + 1] = p[k];
                    rem_val = rem_val - p[k];
                    k++;
                }

                // Copy rem_val to next position and increment position
                p[k + 1] = rem_val;
                k++;
            }
        }

        static void Main(string[] args)
        {
            var testCases = int.Parse(Console.ReadLine());

            List<int[]> outputs = new List<int[]>();

            while(testCases > 0)
            {
                var itemsStr = Console.ReadLine().Split(' ');

                int[] items = new int[3];

                for(int x = 0; x < itemsStr.Length; ++x)
                {
                    items[x] = int.Parse(itemsStr[x]);
                }
                printAllUniqueParts(items[0]);

                var output = partitions.FindAll(p => p.Length == items[2] && p.Length == p.Distinct().Count() && p.Max() <= items[1]);
                if (output.Count > 0)
                {
                    outputs.Add(output[0]);
                } else
                {
                    outputs.Add(new int[1] { -1 });
                }
                testCases--;
            }

            for(int o = 0; o < outputs.Count; ++o)
            {
                
                for(int x = outputs[o].Length - 1; x >=0 ; --x)
                {                    
                    if (x < outputs[o].Length - 1)
                    {
                        Console.Write(" ");
                    }

                    Console.Write(outputs[o][x]);
                }

                Console.WriteLine();

            }
            
            Console.ReadLine();
        }
    }
}
