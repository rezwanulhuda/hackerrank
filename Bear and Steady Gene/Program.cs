using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bear_and_Steady_Gene
{
    class Solution
    {
        static void Main(string[] args)
        {

            int chars = 0;
            string s = String.Empty;

            if (args.Length > 0)
            {
                string[] lines = File.ReadAllLines(args[0]);
                chars = int.Parse(lines[0]);
                s = lines[1];
            }
            else
            {
                chars = int.Parse(Console.ReadLine());
                s = Console.ReadLine();
            }
            



            int requiredCharsPerLetters = chars / 4;

            Dictionary<char, int> originalDistribtion = new Dictionary<char, int>();
            char[] geneLetters = new char[4] { 'A', 'C', 'T', 'G' };

            foreach(char c in geneLetters)
            {
                var gap = requiredCharsPerLetters - s.Count(p => p == c);
                originalDistribtion.Add(c, gap);                    
            }

            if (originalDistribtion.All(p => p.Value == 0)) {
                Console.WriteLine(0);
                return;
            }
            
            int originalMinCharsRequired = originalDistribtion.Sum(p => p.Value > 0 ? p.Value : 0);
            int minCharsRequired = originalMinCharsRequired;

            while(true)
            {
                for (int x = 0; x < s.Length; ++x)
                {

                    if (x + minCharsRequired > s.Length) break;

                    var sub = s.Substring(x, minCharsRequired);

                    int roomInSub = 0;

                    foreach (var dist in originalDistribtion.Where(p => p.Value < 0))
                    {
                        roomInSub += sub.Count(p => p == dist.Key);
                    }

                    if (roomInSub == originalMinCharsRequired)
                    {
                        Console.WriteLine(minCharsRequired);
                        //Console.ReadLine();
                        return;
                    }
                    continue;
                }
                minCharsRequired++;

                if (minCharsRequired > s.Length)
                {
                    break;
                }
            }
                        
        }
    }
}
