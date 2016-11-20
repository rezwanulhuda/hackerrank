using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{

    

    public class Program
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
                if (count > total + 1) return null;

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

        static void PrintArray(long[] arr)
        {
            string s = String.Empty;
            for (long x = 1; x < arr.Length; ++x)
            {
                if (x > 1)
                {
                    s += " ";
                }
                s += arr[x].ToString();
            }

            Console.WriteLine(s);
        }

        static void Main(string[] args)
        {
            ComboGenerator cgn = new ComboGenerator(20, 1);
            var arr = cgn.Next();
            while (arr != null)
            {
                PrintArray(arr);
                arr = cgn.Next();
            }

            //CobinationGenerator c = new CobinationGenerator();
            //c.GenerateCombo(9, 8);
            Console.ReadLine();

        }
    }
}
