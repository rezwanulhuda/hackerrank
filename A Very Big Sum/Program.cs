using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static void Main(String[] args)
    {
        Console.ReadLine();
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
        long sum = 0;

        foreach(int v in arr)
        {
            sum += v;
        }

        Console.WriteLine(sum);
    }
}