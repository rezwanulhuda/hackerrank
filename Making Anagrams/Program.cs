using System;
using System.Linq;

namespace Making_Anagrams
{
    class Solution
    {
        static int findDiff(string s1, string s2)
        {
            int count = 0;
            foreach(char c in s1.Distinct())
            {
                var diff = s1.Count(p => p == c) - s2.Count(p => p == c);
                if (diff > 0)
                {
                    count += diff;
                }
            }

            return count;
        }


        static void Main(string[] args)
        {
            var s1 = Console.ReadLine();
            var s2 = Console.ReadLine();

            Console.WriteLine(findDiff(s1, s2) + findDiff(s2, s1));
            //Console.ReadLine();


        }
    }
}
