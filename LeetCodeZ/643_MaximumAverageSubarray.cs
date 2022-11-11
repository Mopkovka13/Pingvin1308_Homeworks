using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeZ
{
    public static class MaximumAverageSubarray
    {
        public static void Test()
        {
            Console.WriteLine(FindMaxAverage(new int[] { 5 }, 1));
        }

        private static double FindMaxAverage(int[] nums, int k)
        {
            if (nums.Length == 0)
                return 0;
            double max = int.MinValue;
            int tempMax = 0;
            for (int i = 0; i < nums.Length - k + 1; i++)
            {
                tempMax = 0;
                for (int j = 0; j < k; j++)
                {
                    tempMax += nums[i + j];
                }
                if (tempMax > max)
                    max = tempMax;
            }
            return max / k;
        }

    }
}
