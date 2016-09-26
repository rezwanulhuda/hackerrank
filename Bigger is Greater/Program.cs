using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigger_is_Greater
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
                var input = Console.ReadLine();

                var inputChars = input.ToCharArray();

                bool found = false;
                for (int x = inputChars.Length - 1; x > 0; --x)
                {
                    if (inputChars[x] > inputChars[x-1])
                    {
                        var larger = x;

                        for(var y = x + 1; y < inputChars.Length; ++y)
                        {
                            if (inputChars[y] > inputChars[x-1] && inputChars[y] < inputChars[larger])
                            {
                                larger = y;
                            }
                        }

                        var t = inputChars[x - 1];
                        inputChars[x - 1] = inputChars[larger];
                        inputChars[larger] = t;

                        for (var z = 0; z < inputChars.Length - x - 1; ++z)
                        {
                            for (var y = x; y < inputChars.Length - z - 1; ++y)
                            {


                                if (inputChars[y] > inputChars[y + 1])
                                {
                                    var tmp = inputChars[y];
                                    inputChars[y] = inputChars[y + 1];
                                    inputChars[y + 1] = tmp;
                                }

                            }
                        }
                            

                        Result.Add(new string(inputChars));
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Result.Add("no answer");
                }
                --count;


            }

            foreach (var r in Result)
            {
                Console.WriteLine(r);
            }

            //Console.ReadLine();
        }


    }
}
