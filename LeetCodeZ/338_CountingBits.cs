using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeZ
{
    public static class CountingBits
    {
        public static void Test()
        {
            Console.WriteLine(GetCountBits(5));
            Console.WriteLine(GetCountBits(8));
            Console.WriteLine(GetCountBits(7));
        }
        private static int[] CountBits(int n)
        {
            int[] result = new int[n + 1];
            for(int i = 0; i < n; i++)
            {
                result[i] = GetCountBits(i);
            }
            return result;
        }
        private static int GetCountBits(int x)
        {
            int counter = 0;
            while(x > 0)
            {
                if (x % 2 != 0)
                    counter++;
                x /= 2;
            }
            return counter;
        }

    }
}
