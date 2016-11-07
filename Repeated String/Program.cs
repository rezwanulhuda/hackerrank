using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repeated_String
{
    class Solution
    {
        static void Main(string[] args)
        {
            var s = Console.ReadLine();
            var n = long.Parse(Console.ReadLine());
            var len = s.Count();
            var repeatations = (long)(n / len);
            var remaingChars = (int)(n % len);
            var asIns = s.Count(a => a == 'a');
            var asInRemainging = s.Substring(0, remaingChars).Count(a => a == 'a');
            var count = (asIns * repeatations) + asInRemainging;
            Console.WriteLine(count);

        }
    }
}
