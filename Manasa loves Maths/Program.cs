using System;
using System.Collections.Generic;

namespace Manasa_loves_Maths
{
    class Solution
    {

        static bool IsDivisibleBy8(string s)
        {
            return int.Parse(s) % 8 == 0;

        }
        static bool HasDivisibleBy8Combo(string s)
        {


            if (IsDivisibleBy8(s)) return true;

            char[] chars = s.ToCharArray();

            string s1 = chars[0].ToString() + chars[2].ToString() + chars[1].ToString();
            if (IsDivisibleBy8(s1)) return true;

            s1 = chars[1].ToString() + chars[0].ToString() + chars[2].ToString();
            if (IsDivisibleBy8(s1)) return true;

            s1 = chars[1].ToString() + chars[2].ToString() + chars[0].ToString();
            if (IsDivisibleBy8(s1)) return true;

            s1 = chars[2].ToString() + chars[1].ToString() + chars[0].ToString();
            if (IsDivisibleBy8(s1)) return true;

            s1 = chars[2].ToString() + chars[0].ToString() + chars[1].ToString();
            if (IsDivisibleBy8(s1)) return true;

            return false;

        }
        static void Main(string[] args)
        {
            int cases = int.Parse(Console.ReadLine());

            List<string> answers = new List<string>();

            while(cases > 0)
            {
                cases--;
                string sn = Console.ReadLine();

                if (sn.Length == 1)
                {
                    if (IsDivisibleBy8(sn))
                    {
                        answers.Add("YES");
                    }
                    else
                    {
                        answers.Add("NO");
                    }
                }
                else if (sn.Length == 2)
                {
                    
                    if (IsDivisibleBy8(sn))
                    {
                        answers.Add("YES");
                    }
                    else
                    {
                        char[] s = sn.ToCharArray();
                        char t = s[0];
                        s[0] = s[1];
                        s[1] = t;
                        if (IsDivisibleBy8(new string(s)))
                        {
                            answers.Add("YES");
                        }
                        else
                        {
                            answers.Add("NO");
                        }
                    }
                }
                else
                {
                    bool found = false;
                    for(int x = 0; x < sn.Length - 2; ++x)
                    {
                        string s = sn.Substring(x, 3);
                        if (HasDivisibleBy8Combo(s))
                        {
                            answers.Add("YES");
                            found = true;
                            break;
                        }
                        for(int y = 0; y < x; ++y)
                        {
                            char[] sc = s.ToCharArray();
                            char r = sc[0];
                            sc[0] = sn[y];
                            if (HasDivisibleBy8Combo(new string(sc)))
                            {
                                answers.Add("YES");
                                found = true;
                                break;
                            }

                            sc[0] = r;
                            sc[1] = sn[y];

                            if (HasDivisibleBy8Combo(new string(sc)))
                            {
                                answers.Add("YES");
                                found = true;
                                break;
                            }

                        }

                        if (found) break;
                    }

                    if (!found)
                    {
                        answers.Add("NO");                        
                    }
                }

                

            }

            foreach(var a in answers)
            {
                Console.WriteLine(a);
            }
            //Console.ReadLine();
        }
    }
}
