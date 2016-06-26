using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static void Main(String[] args)
    {
        double countZero = 0.0;
        double countNegative = 0.0;
        double countPositive = 0.0;

        int n = Convert.ToInt32(Console.ReadLine());
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
        foreach(int i in arr)
        {
            if (i == 0)
            {
                countZero++;
            } else if (i > 0)
            {
                countPositive++;
            } else
            {
                countNegative++;
            }
        }

        Console.WriteLine(String.Format("{0:F5}", countPositive / n, countNegative / n, countZero / n));
        Console.WriteLine(String.Format("{0:F5}", countNegative / n));
        Console.WriteLine(String.Format("{0:F5}", countZero / n));
    }
}