using System;
using System.Collections.Generic;
using System.Linq;

namespace Anagram
{
    class Solution
    {
        static void Main(string[] args)
        {
            var cases = int.Parse(Console.ReadLine());

            List<int> answers = new List<int>();
            while(cases > 0)
            {
                cases--;

                var input = Console.ReadLine();
                

                if (input.Length % 2 > 0)
                {
                    answers.Add(-1);
                    continue;
                }

                var s1 = input.Substring(0, input.Length / 2);
                //s1 = new string(s1.OrderBy(p => p).ToArray());                
                var s2 = input.Substring(input.Length / 2);
                //s2 = new string(s2.OrderBy(p => p).ToArray());

                int count = 0;                               
                foreach (char c in s1.Distinct())
                {
                    var diff = s1.Count(p => p == c) - s2.Count(p => p == c);
                    if (diff > 0)
                    {
                        count += diff;                        
                    }
                }

                answers.Add(count);

            }

            foreach(var a in answers)
            {
                Console.WriteLine(a);
            }

            //Console.ReadLine();
        }
    }
}
