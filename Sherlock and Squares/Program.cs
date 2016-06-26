using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());

        List<int> output = new List<int>();

        for(int a0 = 0; a0 < t; ++a0)
        {
            int count = 0;
            string inputLine = Console.ReadLine();
            string[] inputs = inputLine.Split(new char[] { ' ' });

            int first = int.Parse(inputs[0]);
            int last = int.Parse(inputs[1]);

            int start = 0;

            //if (first == 1)
            //{
            //    ++count;
            //    start = first + 1;
            //}
            //else
            //{
               
            //}

            double fSqrt = Math.Sqrt(first);
            if (Math.Floor(fSqrt) == fSqrt)
            {
                ++count;

            }

            start = (int)fSqrt + 1;

            while (start * start <= last)
            {
                ++count;
                ++start;
            }
            output.Add(count);
        }

        foreach (int i in output)
        {
            Console.WriteLine(i);
        }

        //Console.ReadLine();
       
    }
}