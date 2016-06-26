using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        List<int> output = new List<int>();
        for (int a0 = 0; a0 < t; a0++)
        {
            int count = 0;
            int n = Convert.ToInt32(Console.ReadLine());
            string s = n.ToString();
            foreach(char c in s)
            {
                int digit = Int16.Parse(c.ToString());
                if (digit != 0 && n % digit == 0)
                {
                    count++;
                }
            }
            output.Add(count);
                
        }

        foreach(int i in output)
        {
            Console.WriteLine(i);
        }
        
    }
}
