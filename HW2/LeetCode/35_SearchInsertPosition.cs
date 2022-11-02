namespace LeetCode
{
    public static class SearchInsertPosition
    {
        public static void Test()
        {
            int[] array = {1, 3, 5, 6};
            Console.WriteLine(GetSearchInsert(array, 7));
        }

        private static int GetSearchInsert(int[] nums, int target)
        {
            for(int i = 0; i < nums.Length; i++)
            {
                if(nums[i] > target)
                    return i;
            }
            return nums.Length;
        }
    }
}
