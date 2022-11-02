namespace LeetCode
{
    public static class RemoveDuplicates
    {
        public static void Test()
        {
            int[] array = { 1, 1, 2 };

            Console.WriteLine(GetRemoveDuplicates(array)); 
            foreach(var item in array)
            {
                Console.Write(item + " ");
            }
        }

        private static int GetRemoveDuplicates(int[] nums)
        {
            var result = nums.Distinct().ToArray();
            for(int i = 0; i < result.Length; i++)
            {
                nums[i] = result[i];
            }
            
            return result.Length;
        }
    }
}
