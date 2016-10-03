using System;
using System.Collections.Generic;
using System.Linq;

namespace Palindrome_Index
{
    class Solution
    {

        static bool isPalindromeWithoutChar(int index, int len, string s)
        {
            var without = s.Substring(index, len);
            var withoutRev = new string(without.Reverse().ToArray());

            return without == withoutRev;
        }

        static void Main(string[] args)
        {
            List<int> output = new List<int>();
            var cases = int.Parse(Console.ReadLine());

            while(cases > 0)
            {
                cases--;
                var s = Console.ReadLine();

                var sRev = new string(s.Reverse().ToArray());

                if (s == sRev)
                {
                    output.Add(-1);
                    continue;
                }

                for(int x = 0, y = s.Length -1; x < s.Length/2; ++x, --y)
                {
                    if (s[x] == s[y]) continue;

                    int index = -1;

                    var len = s.Length - 2 * x - 1;


                    if (isPalindromeWithoutChar(x + 1, len, s))
                    {
                        index = x;
                    }
                    else if (isPalindromeWithoutChar(x, len, s))
                    {
                        index = y;
                    }
                                        
                    output.Add(index);
                    break;                    
                }
                
            }
            foreach(var o in output)
            {
                Console.WriteLine(o);
            }

            //Console.ReadLine();
        }
    }
}
