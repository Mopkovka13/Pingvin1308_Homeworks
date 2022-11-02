using System;

namespace LeetCode
{
    public static class RemoveElement
    {
        public static void Test()
        {
            int[] array = { 3, 2, 2, 3 };

            Console.WriteLine(GetRemoveElement(array, 3));
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }

        }
        private static int GetRemoveElement(int[] nums, int val)
        {
            int indexVal = nums.Length - 1;
            int i = 0;

            while(indexVal > i)
            {
                while (nums[indexVal] == val && indexVal > 0)
                {
                    indexVal--;
                }
                if (indexVal < i)
                    break;
                if (nums[i] == val) //Меняем местами
                {
                    int temp = nums[indexVal];
                    nums[indexVal] = nums[i];
                    nums[i] = temp;
                    indexVal--;
                }
                i++;
            }

            for(i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                    break;
            }

            return i;
        }
    }
}
