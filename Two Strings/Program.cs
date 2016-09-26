using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Strings
{
    class Solution
    {
        static void Main(String[] args)
        {
            var cnt = Console.ReadLine();

            var count = int.Parse(cnt);
            var Result = new List<string>();

            while (count > 0)
            {
                var s1 = Console.ReadLine();
                var s2 = Console.ReadLine();

                bool found = false;
                for(var c = 'a'; c <= 'z'; ++c)
                {                    
                    if (s1.Contains(c.ToString()) && s2.Contains(c.ToString()))
                    {
                        found = true;
                        break;
                    }
                }

                if(found)
                    Result.Add("YES");
                else
                    Result.Add("NO");
                count--;
            }

            foreach(var r in Result)
            {
                Console.WriteLine(r);
            }
            //Console.ReadLine();
        }

        
    }
}
