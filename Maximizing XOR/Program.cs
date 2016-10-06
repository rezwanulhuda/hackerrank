using System;

namespace Maximizing_XOR
{
    class Sulution
    {
        static void Main(string[] args)
        {
            var first = int.Parse(Console.ReadLine());
            var second = int.Parse(Console.ReadLine());

            var diff = second^first;
            
            var bits = Math.Floor(Math.Log(diff) / Math.Log(2)) + 1;

            int result = (int)Math.Pow(2, bits) - 1;

            Console.WriteLine(result);

            //Console.ReadLine();
        }
    }
}
