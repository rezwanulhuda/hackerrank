using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insertion_Sort___Part_1
{
    class Solution
    {
        static void print(int[] items)
        {
            string output = String.Empty;
            for(int x = 0; x < items.Length; ++x)
            {
                if (x > 0)
                {
                    output += " ";
                }
                output += items[x];
            }

            Console.WriteLine(output);
        }
        static void Main(string[] args)
        {
            Console.ReadLine();
            int[] sortedItems = null;
            int itemToInsert;
            var items = Console.ReadLine().Split(' ');

            itemToInsert = int.Parse(items[items.Length - 1]);
            sortedItems = new int[items.Length];
            for(int y = 0; y < items.Length - 1; ++y)
            {
                sortedItems[y] = int.Parse(items[y]);
            }

            int x = 0;
            for(; x < sortedItems.Length - 1; ++x)
            {
                if (itemToInsert >= sortedItems[x]) continue;

                for (int y = sortedItems.Length - 2; y >= x; --y)
                {
                    sortedItems[y + 1] = sortedItems[y];
                    print(sortedItems);
                }

                break;

            }

            sortedItems[x] = itemToInsert;
            print(sortedItems);

            //Console.ReadLine();


        }
    }
}
