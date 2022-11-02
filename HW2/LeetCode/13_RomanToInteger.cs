namespace LeetCode
{
    public static class RomanToInteger
    {
        private static Dictionary<char, int> Symbols = new Dictionary<char, int>()
        {
            {'I', 1 },
            {'V', 5 },
            {'X', 10 },
            {'L', 50 },
            {'C', 100 },
            {'D', 500 },
            {'M', 1000 }
        };

        public static void Test()
        {
            Console.WriteLine(RomanToInt("IXIXXX") + " - 38");
            Console.WriteLine(RomanToInt("XXX") + " - 30");
            Console.WriteLine(RomanToInt("MCMXCIV") + " - 1994");
        }

        private static int RomanToInt(string s)
        {
            if (s.Length == 0)
                return 0;

            int result = Symbols[s[0]];
            for(int i = 1; i < s.Length; i++)
            {
                if (Symbols[s[i - 1]] < Symbols[s[i]])
                {
                    result -= Symbols[s[i - 1]] * 2;
                }
                result += Symbols[s[i]];     
            }
            return result;
        }
    }
}
