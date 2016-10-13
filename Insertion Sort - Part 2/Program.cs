using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insertion_Sort___Part_2
{
    class Solution
    {
        static void Print(int[] items)
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

        static void Insert(int itemToInsert, int itemsInserted, int[] sortedItems)
        {
            int x = 0;
            for (; x < itemsInserted; ++x)
            {
                if (itemToInsert >= sortedItems[x]) continue;

                for (int y = itemsInserted - 1; y >= x; --y)
                {
                    sortedItems[y + 1] = sortedItems[y];                    
                }

                break;

            }

            sortedItems[x] = itemToInsert;
            Print(sortedItems);
        }


        static void Main(string[] args)
        {
            Console.ReadLine();
            int[] sortedItems = null;

            var items = Console.ReadLine().Split(' ');
            
            sortedItems = new int[items.Length];
            for(int y = 0; y < items.Length; ++y)
            {
                sortedItems[y] = int.Parse(items[y]);
            }

            for(int x = 1; x < sortedItems.Length; ++x)
            {
                Insert(sortedItems[x], x, sortedItems);
            }
        }
    }
}
