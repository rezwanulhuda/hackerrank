using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Conversion
{
    class Solution
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            DateTime d = DateTime.ParseExact(input, "hh:mm:sstt", null);
            Console.WriteLine(d.ToString("HH:mm:ss"));
            //Console.ReadLine();
        }
    }
}
