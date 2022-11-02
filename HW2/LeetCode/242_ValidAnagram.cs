namespace LeetCode
{
    public static class ValidAnagram
    {
        public static void Test()
        {
            Console.WriteLine(IsAnagram("rat", "car"));
        }

        private static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            var arrayCharS = s.ToCharArray();
            Array.Sort(arrayCharS);
            s = new String(arrayCharS);
            Console.WriteLine(s);

            var arrayCharT = t.ToCharArray();
            Array.Sort(arrayCharT);
            t = new String(arrayCharT);
            Console.WriteLine(t);


            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] != t[i])
                    return false;
            }
            return true;
        }
    }
}
