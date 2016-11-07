using System;
using System.IO;

namespace Jumping_on_the_Clouds
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

            var n = int.Parse(reader.ReadLine());
            var c = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);

            int jumps = 0;
            int current = 0;

            while(current < c.Length)
            {            
                if (current + 2 < c.Length)
                {
                    if (c[current + 2] != 1)
                    {
                        current += 2;
                    }
                    else
                    {
                        current += 1;
                    }
                }
                else if (current + 1 < c.Length)
                {
                    current += 1;
                } else
                {
                    break;
                }



                jumps++;
            }

            Console.WriteLine(jumps);

            
        }
    }
}
