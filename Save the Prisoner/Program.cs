using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Save_the_Prisoner
{
    class Solution
    {
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

            var t = int.Parse(reader.ReadLine());
            while (t > 0)
            {
                t--;
                var input = reader.ReadLine().Split(' ');
                var n = long.Parse(input[0]);
                var m = long.Parse(input[1]);
                var s = long.Parse(input[2]);
                long remainging = 0;
                if (n >= m)
                {
                    remainging = m;
                }
                else
                {
                    remainging = m % n;
                }

                long result = s + remainging - 1;
                if (result > n)
                {
                    result = n - result;
                }

                Console.WriteLine(Math.Abs(result));                
            }
            //Console.ReadLine();
        }
    }
}
