using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{

    public class ComboGenerator
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
    public class CobinationGenerator
    {
        
        public void PrintArray(long[] arr)
        {
            string s = String.Empty;
            for(long x = 1; x < arr.Length; ++x)
            {
                if (x > 1)
                {
                    s += " ";
                }
                s += arr[x].ToString();                
            }

            Console.WriteLine(s);
        }

        public bool IsSumEquals(long[] arr, long sum)
        {
            return arr.Sum() == sum;
        }

        public void GenerateCombo(long n, long r)
        {
            long[] currentCombo = new long[r + 1];
            for(long x = 1; x <= r; ++x)
            {
                currentCombo[x] = x;
            }
            PrintArray(currentCombo);

            long y = r;

            while(true)
            {
                while(currentCombo[y] < n)
                {
                    currentCombo[y] = currentCombo[y] + 1;
                    PrintArray(currentCombo);
                }

                while(currentCombo[y] >= n - (r - y))
                {
                    y--;                    
                }

                long tmp = currentCombo[y] + 1;
                
                if (y == 1 && tmp >= n - (r - y))
                {
                    currentCombo[y] = tmp;
                    PrintArray(currentCombo);
                    break;
                }
                
                while (y <= r)
                {
                    currentCombo[y] = tmp;
                    y++; tmp++;
                }
                PrintArray(currentCombo);
                y--;
                continue;

            }
        }
    }

    public class Program
    {
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
