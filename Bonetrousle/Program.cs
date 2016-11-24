using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Bonetrousle
{    
    class Solution
    {
        private class ComboGeneratorReverse
        {
            long n;
            long r;
            long[] currentCombo = null;
            long y;
            long total;
            long count;
            public ComboGeneratorReverse(long n, long r)
            {
                this.n = n;
                this.r = r;
                this.y = r;
                this.count = 0;
                this.total = (long)(FactByFact(n, n - r) / Fact(r));
            }

            void GenerateFirst()
            {
                this.currentCombo = new long[r + 1];
                for (long x = 1; x <= r; ++x)
                {
                    currentCombo[x] = n - x + 1;
                }

                count++;
            }

            public long[] Next()
            {
                if (total == 0) return null;
                count++;
                if (count > total + 1) return null;

                if (currentCombo == null)
                {
                    GenerateFirst();

                }
                else
                {
                    if (currentCombo[y] > r - y - 1)
                    {
                        currentCombo[y] = currentCombo[y] - 1;
                        return currentCombo;
                    }
                    y--;
                    while (y > 0 && currentCombo[y] < n - y - 1)
                    {
                        y--;
                    }

                    long tmp = currentCombo[y] - 1;

                    if (y == 1 && tmp < n - y - 1)
                    {
                        currentCombo[y] = tmp;
                        return currentCombo;
                    }

                    while (y <= r && tmp > r - y + 1)
                    {
                        currentCombo[y] = tmp;
                        y++; tmp--;
                    }
                    y--;

                    if (y > 1)
                    {
                        
                    }
                    return currentCombo;
                }

                return currentCombo;
            }

        }

        static decimal FactByFact(decimal f1, decimal f2)
        {
            decimal n1 = Math.Max(f1, f2);
            decimal n2 = Math.Min(f1, f2);

            decimal result = 1;

            while (n1 > n2)
            {
                result *= n1;
                n1--;
            }

            return result;

        }

        static decimal Fact(long n)
        {
            if (n == 1) return 1;

            decimal result = 1;
            while (n > 1)
            {

                result = result * n;
                n--;
            }

            return result;
        }

        private interface ILineReader
        {
            string ReadLine();
        }

        private class FileLineReader : ILineReader
        {

            string[] lines;
            int currentLine = 0;
            public FileLineReader(string fileName)
            {
                lines = File.ReadAllLines(fileName);
            }

            public string ReadLine()
            {
                string s = lines[currentLine];
                currentLine++;
                return s;
            }
        }

        private class ConsoleLineReader : ILineReader
        {
            public string ReadLine()
            {
                return Console.ReadLine();
            }
        }

        static string PrintArray(long[] arr)
        {
            string s = String.Empty;
            for (long x = 1; x < arr.LongLength; ++x)
            {
                if (x > 1)
                {
                    s += " ";
                }
                s += arr[x].ToString();
            }
            return s;
        }

        static ulong SumUpTo(ulong n)
        {            
            return (n * (n + 1)) / 2;
        }

        static void Main(string[] args)
        {
            ComboGeneratorReverse cgn = new ComboGeneratorReverse(6, 3);
            var combo = cgn.Next();
            var count = 0;
            while(combo != null)
            {
                count++;
                Console.WriteLine(PrintArray(combo));
                combo = cgn.Next();
                
            }

            Console.WriteLine("Total: {0}", count);
            /*ILineReader reader;

            if (args.Length > 0)
            {
                reader = new FileLineReader(args[0]);
            }
            else
            {
                reader = new ConsoleLineReader();
            }


            int testCases = int.Parse(reader.ReadLine());

            List<string> results = new List<string>();

            while(testCases > 0)
            {
                testCases--;
                var input = reader.ReadLine().Split(' ');
                var n = long.Parse(input[0]);
                var k = long.Parse(input[1]);
                var b = long.Parse(input[2]);

                if (SumUpTo((ulong)b) > (ulong)n || SumUpTo((ulong)k) < (ulong)n)
                {
                    results.Add("-1");
                    continue;
                }
                ComboGeneratorReverse cgn = new ComboGeneratorReverse(k, b);
                var combo = cgn.Next();
                
                while(combo != null)
                {
                    var sum = combo.Sum();
                    if (sum == n)
                    {                        
                        results.Add(PrintArray(combo));
                        break;
                    }
                    combo = cgn.Next();
                }

                if (combo == null)
                {
                    results.Add("-1");
                }

            }

            foreach(var r in results)
            {
                Console.WriteLine(r);
            }*/

            Console.ReadLine();
        }
    }
}
