using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    class ShortestSubString
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ShortestSubstring("aabdedn"));
        }

        public static int ShortestSubstring(string s)
        {
            Dictionary<char, bool> uniqueChars = s.Distinct().ToDictionary(c => c, c => false);
            List<char> keys = new List<char>(uniqueChars.Keys);
            var substring = new List<string>();
            var subtempstring = string.Empty;

            foreach (char c in s)
            {
                uniqueChars[c] = true;
                subtempstring = subtempstring + c;
                if (!uniqueChars.Any(x => x.Value == false))
                {
                    substring.Add(subtempstring);
                    subtempstring = string.Empty;
                    foreach (var key in keys)
                    {
                        uniqueChars[key] = false;
                    }
                }
            }

            return substring.Select(y => y.Length).Min();
        }
    }
}
