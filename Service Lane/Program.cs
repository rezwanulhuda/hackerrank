using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static void Main(String[] args)
    {
        List<int> output = new List<int>();

        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int t = Convert.ToInt32(tokens_n[1]);
        string[] width_temp = Console.ReadLine().Split(' ');
        int[] width = Array.ConvertAll(width_temp, Int32.Parse);
        for (int a0 = 0; a0 < t; a0++)
        {
            string[] tokens_i = Console.ReadLine().Split(' ');
            int i = Convert.ToInt32(tokens_i[0]);
            int j = Convert.ToInt32(tokens_i[1]);

            int min = width[i];

            while(i + 1 <= j)
            {
                min = Math.Min(min, width[i+1]);
                ++i;
            }

            output.Add(min);
        }

        foreach (int i in output)
        {
            Console.WriteLine(i);
        }

        //Console.ReadLine();
    }
}