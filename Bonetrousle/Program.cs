using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Bonetrousle
{    
    class Solutino
    {
        private class ComboGenerator
        {
            long n;
            long r;
            long[] currentCombo = null;
            long y;
            bool done;

            public ComboGenerator(long n, long r)
            {
                this.n = n;
                this.r = r;
                this.y = r;
                this.done = false;
            }

            void GenerateFirst()
            {
                this.currentCombo = new long[r + 1];
                for (long x = 1; x <= r; ++x)
                {
                    currentCombo[x] = x;
                }
                done = false;
            }

            public long[] Next()
            {
                if (done == true)
                {
                    return null;
                }

                if (currentCombo == null)
                {
                    GenerateFirst();

                }
                else
                {
                    if (currentCombo[y] < n)
                    {
                        currentCombo[y] = currentCombo[y] + 1;
                        if (y == 1 && r == 1 && currentCombo[y] == n)
                        {
                            done = true;
                        }
                        return currentCombo;
                    }

                    while (currentCombo[y] >= n - (r - y))
                    {
                        y--;
                    }

                    long tmp = currentCombo[y] + 1;

                    if (y == 1 && tmp >= n - (r - y))
                    {
                        currentCombo[y] = tmp;
                        done = true;
                        return currentCombo;
                    }

                    while (y <= r)
                    {
                        currentCombo[y] = tmp;
                        y++; tmp++;
                    }
                    y--;
                    return currentCombo;
                }

                return currentCombo;
            }

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
            ILineReader reader;

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

                //n = n / 10000;
                //k = k / 10000;
                //b = b / 10000;

                if (SumUpTo((ulong)b) > (ulong)n || SumUpTo((ulong)k) < (ulong)n)
                {
                    results.Add("-1");
                    continue;
                }
                ComboGenerator cgn = new ComboGenerator(k, b);
                var combo = cgn.Next();
                
                while(combo != null)
                {
                    var sum = combo.Sum();
                    if (sum == n)
                    {
                        //for(int x = 0; x < combo.Length; ++x)
                        //{
                        //    combo[x] = combo[x] * 10000;
                        //}
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
            }

            Console.ReadLine();
        }
    }
}
