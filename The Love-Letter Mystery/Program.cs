using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        List<int> output = new List<int>();

        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int t = Convert.ToInt32(Console.ReadLine());

        while(t > 0)
        {
            string input = Console.ReadLine();
            int operations = 0;

            for (int x = 0, y = input.Length - 1; x < y;  ++x, --y)
            {

                operations += Math.Abs(input[x] - input[y]);
            }
            output.Add(operations);
            --t;
        }

        foreach(var o in output)
        {
            Console.WriteLine(o);
        }

        //Console.ReadLine();

    }
}