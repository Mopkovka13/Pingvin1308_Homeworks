namespace LeetCode
{
    public static class PlusOne
    {
        public static void Test()
        {
            foreach (var item in GetPlusOne(new int[] { 9, 9, 9 }))
            {
                Console.Write(item + " ");
            }
        }

        public static int[] GetPlusOne(int[] digits)
        {
            for(int i = digits.Length-1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    break;
                }
                if (digits[i] == 9)
                {
                    digits[i] = 0;
                }
            }

            if (digits[0] == 0) //Если в начале 0, значит число вышло за разряды
            {
                int[] result = new int[digits.Length + 1];
                result[0] = 1;
                for(int i = 0; i < digits.Length; i++)
                {
                    result[i + 1] = digits[i];
                }
                return result;
            }
            return digits;
        }
    }
}
