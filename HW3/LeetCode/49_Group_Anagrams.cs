using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class Group_Anagrams
    {
        public static void Test()
        {
            var result = GroupAnagrams(new string[]{ "eat", "tea", "tan", "ate", "nat", "bat"});
            foreach(var item in result)
            {
                foreach(var i in item)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine();
            }
        }
        
        private static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var groupAnagrams = strs.GroupBy(x => x.Sort()); //По факту всё решение с методом расширения

            IList<IList<string>> result = new List<IList<string>>(); //Но тут необходимо привести к IList<IList<string>> и понеслись костыли ))
            foreach(var anagram in groupAnagrams)
            {
                List<string> temp = new List<string>();
                foreach(var item in anagram)
                {
                    temp.Add(item);
                }
                result.Add(temp);
            }
            return result;
        }

        public static string Sort(this string str)
        {
            var charArray = str.ToCharArray();
            Array.Sort(charArray);
            return new String(charArray);
        }
    }
}
