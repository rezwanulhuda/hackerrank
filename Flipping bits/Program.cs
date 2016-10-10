using System;
using System.Collections.Generic;

namespace Flipping_bits
{
    class Solution
    {
        static void Main(string[] args)
        {
            List<uint> answers = new List<uint>();
            var testCases = int.Parse(Console.ReadLine());
            uint allOnes = (uint)Math.Pow(2, 32) - 1;
            while(testCases > 0)
            {
                testCases--;
                var t1 = uint.Parse(Console.ReadLine());

                answers.Add(t1 ^ allOnes);

            }

            foreach(var a in answers)
            {
                Console.WriteLine(a);
            }

            //Console.ReadLine();
        }
    }
}
