namespace LeetCode
{
    public static class ValidParentheses
    {
        private static readonly Dictionary<char, char> _pairs = new Dictionary<char, char>()
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' }
        };

        public static void Test()
        {
            Console.WriteLine(IsValid2("{{{}]]]{"));
            Console.WriteLine(IsValid2("{}[]"));
        }

        private static bool IsValid(string s)
        {
            string array = "([{}])";

            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i + 1] != array[array.Length - 1 - array.IndexOf(s[i])])
                {
                    return false;
                }
                i++;
            }
            return true;
        }

        private static bool IsValid2(string s)
        {
            if(string.IsNullOrEmpty(s))
            {
                return false;
            }

            var stack = new Stack<char>();
            foreach(var symbol in s)
            {
                if (_pairs.ContainsKey(symbol))
                {
                    stack.Push(symbol);
                }
                else if (!_pairs.ContainsValue(symbol))
                {
                    continue;
                }
                else if (stack.Count == 0)
                {
                    return false;
                }
                else if (_pairs[stack.Pop()] != symbol)
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
    }
}
