using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeZ
{
    public static class UniqueEmailAddresses
    {
        public static void Test()
        {
            Console.WriteLine(NumUniqueEmails(new string[] { "test.email+alex@leetcode.com" , "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" }));
        }
        public static int NumUniqueEmails(string[] emails)
        {

            for(int i = 0; i < emails.Length; i++)
            {
                string[] names = emails[i].Split('@');
                string[] localName = names[0].Split('+');
                localName[0] = localName[0].Replace(".", "");
                emails[i] = localName[0] + names[1];
            }
            return emails.Distinct().Count();
        }
    }
}
