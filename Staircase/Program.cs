using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static void Main(String[] args)
    {

        int n = Convert.ToInt32(Console.ReadLine());
        int count = 1;
        while(count <= n)
        {            
            Console.WriteLine("".PadRight(count++, '#').PadLeft(n));        
        }        
    }
}
