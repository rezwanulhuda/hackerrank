using System;
using System.Collections.Generic;

namespace Red_John_is_Back
{
    class Solution
    {

        static decimal FactByFact(decimal f1, decimal f2)
        {
            decimal n1 = Math.Max(f1, f2);
            decimal n2 = Math.Min(f1, f2);

            decimal result = 1;

            while(n1 > n2)
            {
                result *= n1;
                n1--;
            }

            return result;

        }
        static decimal Fact(int n)
        {
            if (n == 1) return 1;

            decimal result = 1;
            while(n > 1)
            {
                
                result = result * n;
                n--;
            }

            return result;
        }

        static int NrOfPrimes(decimal n)
        {

            if (n <= 1) return 0;
            int count = 1;
            for(int x = 2; x <= n; ++x)
            {
                int maxTry = (int)Math.Sqrt(x) + 1;
                bool isPrime = true;
                for(int y = 2; y <= maxTry; ++y)
                {
                    if (x % y == 0)
                    {
                        isPrime = false;          
                        break;
                    }
                }

                if (isPrime) count++;
            }

            return count;
        }

        
        static void Main(string[] args)
        {
            int testCases = int.Parse(Console.ReadLine());

            List<decimal> answers = new List<decimal>();

            while(testCases > 0)
            {
                testCases--;
                int N = int.Parse(Console.ReadLine());

                decimal total = 1;

                int maxOneXFourBlocks = (int)N / 4;
                int remainingFourXOneBlock = N % 4;

                while(maxOneXFourBlocks > 0)
                {
                    int pieces = maxOneXFourBlocks + remainingFourXOneBlock;

                    decimal r = 1;
                    if (maxOneXFourBlocks > remainingFourXOneBlock)
                    {
                        r = FactByFact(pieces, maxOneXFourBlocks);
                        total += r / Fact(remainingFourXOneBlock);
                    }
                    else
                    {
                        r = FactByFact(pieces, remainingFourXOneBlock);
                        total += r / Fact(maxOneXFourBlocks);
                    }                    

                    maxOneXFourBlocks--;
                    remainingFourXOneBlock += 4;
                }


                answers.Add(NrOfPrimes(total));
            }

            foreach(var answer in answers)
            {
                Console.WriteLine(answer);
            }

            //Console.ReadLine();
        }
    }
}
