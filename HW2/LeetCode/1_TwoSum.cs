namespace LeetCode
{
    public static class TwoSum
    {
        public static void Test()
        {
            string result1 = "[" +  String.Join(", ", GetTwoSum(new int[] { 2, 7, 11, 15 }, 9)) + "]";
            string result2 = "[" +  String.Join(", ", GetTwoSum(new int[] { 3, 2, 4 }, 6)) + "]";
            string result3 = "[" +  String.Join(", ", GetTwoSum(new int[] { 3, 3 }, 6)) + "]";

            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);
        }

        private static int[] GetTwoSum(int[] nums, int target)
        {
            for(int i = 0; i < nums.Length; i++)
            {
                for(int j = 0; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target && i != j)
                        return new int[] { i, j };
                }
            }
            return new int[] {-1, -1};
        }
    }
}
