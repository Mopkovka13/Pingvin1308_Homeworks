using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeZ
{
    public static class PalindromeNumber
    {
        public static void Test()
        {
            Console.WriteLine(IsPalindrome(10101));
        }
        private static bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;

            int size = 0;
            int temp = x;
            while(temp > 0)
            {
                temp /= 10;
                size++;
            }

            while(size > 0)
            {
                if (size == 1)
                    return true;
                if (x % 10 == (int)(x / Math.Pow(10, size - 1)))
                {
                    x = (int)(x % Math.Pow(10, size - 1));
                    x = (int)(x / 10);
                    Console.WriteLine(x);
                    size -= 2;
                }
                else
                    return false;
            }
            return true;
        }
    }
    
}
