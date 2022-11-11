using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeZ
{
    public static class MoveZeroes
    {
        public static void Test()
        { 

            int[] nums = { 0, 1, 0, 3, 12 };
            GetMoveZeroes(nums);
            foreach(var item in nums)
            {
                Console.Write(item + " ");
            }
        }
        
        private static void GetMoveZeroes(int[] nums)
        {
            int j = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    int temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                    j++;
                }
            }
        }
    }
}
