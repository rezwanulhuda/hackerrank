using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static void Main(String[] args)
    {
        List<int> output = new List<int>();

        //int n = Convert.ToInt32();
        Console.ReadLine();
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);

        Array.Sort(arr);
        output.Add(arr.Length);

        int start = 0;
        while (start < arr.Length - 1)
        {
            if (arr[start] != arr[start+1])
            {
                output.Add(arr.Length - start - 1);
            }
            ++start;
        }

        foreach (int i in output)
        {
            Console.WriteLine(i);
        }

        //Console.ReadLine();
        
    }
}
