using System;
using System.Linq;

namespace Game_of_Thrones___I
{
    class Solution
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();


            int oddCount = 0;

            foreach(var c in input.Distinct())
            {
                var charCount = input.ToArray().Count(p => p == c);
                if (charCount % 2 == 0) continue;

                oddCount++;
                if (oddCount > 1)
                    break;
            }

            if (oddCount > 1)
            {
                Console.WriteLine("NO");
            } else
            {
                Console.WriteLine("YES");
            }

            //Console.ReadLine();
        }
    }
}
