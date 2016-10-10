using System;
using System.Linq;

namespace CamelCase
{
    class Solution
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Console.WriteLine(input.Count(p => p >= 'A' && p <= 'Z') + 1);
            //Console.ReadLine();
        }
    }
}
