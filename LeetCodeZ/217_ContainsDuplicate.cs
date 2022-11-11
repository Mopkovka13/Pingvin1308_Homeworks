using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeZ
{
    public static class ContainsDuplicate
    {
        public static void Test()
        {
            Console.WriteLine(GetContainsDuplicate(new int[]{1,2,3,1 }));
        }
        private static bool GetContainsDuplicate(int[] nums)
        {
            var temp = nums.Distinct();
            return temp.Count() != nums.Length ? true : false;
        }
    }
}
