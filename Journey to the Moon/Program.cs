using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Journey_to_the_Moon
{
    class Solution
    {
        private class ComboGenerator
        {
            long n;
            long r;
            long[] currentCombo = null;
            long y;            
            long total;
            long count;
            public ComboGenerator(long n, long r)
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
                    currentCombo[x] = x;
                }
                count++;                
            }

            public long[] Next()
            {
                if (total == 0) return null;
                count++;
                if (count > total+1) return null;
                
                if (currentCombo == null)
                {
                    GenerateFirst();

                }
                else
                {
                    if (currentCombo[y] < n)
                    {
                        currentCombo[y] = currentCombo[y] + 1;                        
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

        private class Country
        {
            public List<int> members = new List<int>();

            public bool IsInCountry(int member)
            {
                return members.Contains(member);
            }

            public void Add(int member)
            {
                if (!IsInCountry(member))
                {
                    members.Add(member);
                }
            }

            public void Add(List<int> members)
            {
                this.members.AddRange(members);
                this.members = this.members.Distinct().ToList();
            }

            public int Count
            {
                get { return members.Count;  }
            }
        }

        private class ParticipantsInCountries
        {
            public List<Country> countries = new List<Country>();

            public void Add(int p1, int p2)
            {
                var country = countries.Find(p => p.IsInCountry(p1));
                if (country != null) 
                {
                    var c2 = countries.Find(p => p.IsInCountry(p2));
                    if (c2 != null)
                    {
                        if (c2 != country)
                        {
                            country.Add(c2.members);
                            this.countries.Remove(c2);
                        }                        
                    }
                    else
                    {
                        country.Add(p2);
                    }
                    
                    return;
                }
                                
                country = countries.Find(p => p.IsInCountry(p2));
                if (country != null)
                {
                    country.Add(p1);
                    return;
                }

                country = new Country();
                country.Add(p1);
                country.Add(p2);
                countries.Add(country);

            }

            public void Normalize()
            {
                foreach(var country in this.countries)
                {
                    country.members = country.members.Distinct().ToList();
                }
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

            var input = reader.ReadLine().Split(' ');
            var N = int.Parse(input[0]);
            var I = int.Parse(input[1]);

            var pic = new ParticipantsInCountries();

            while (I > 0)
            {
                I--;
                input = reader.ReadLine().Split(' ');
                var p1 = int.Parse(input[0]);
                var p2 = int.Parse(input[1]);
                pic.Add(p1, p2);
            }
            
            pic.Normalize();

            var total = pic.countries.Sum(p => p.members.Count);
            var singleGroups = N - total;
            
            ComboGenerator cg = new ComboGenerator(pic.countries.Count, 2);
            long sum = 0;

            var combo = cg.Next();
            while(combo != null)
            {
                sum += pic.countries[(int)combo[1] - 1].Count * pic.countries[(int)combo[2] - 1].Count;
                combo = cg.Next();
            }

            var singleCombo = (long)(FactByFact(singleGroups, singleGroups - 2) / Fact(2));
            var comboIntoCountry = pic.countries.Sum(p => p.members.Count * singleGroups);
            sum += singleCombo + comboIntoCountry;
            
            Console.WriteLine(sum);            

        }
    }
}
