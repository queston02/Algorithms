using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    class LongestSubstringWithoutRepeatingCharacters
    {
        static void Main()
        {
            Console.WriteLine(LengthOfLongestSubstring("avad"));
        }
        static int LengthOfLongestSubstring(String s)
        {
            int n = s.Length, ans = 0;
            Dictionary<char, int> map = new Dictionary<char, int>(); // current index of character
            // try to extend the range [i, j]
            for (int j = 0, i = 0; j < n; j++)
            {
                if (map.ContainsKey(s[j]))
                {
                    i = Math.Max(map[s[j]], i);
                }
                ans = Math.Max(ans, j - i + 1);
                if (map.ContainsKey(s[j]))
                {
                    map[s[j]] = j + 1;  
                }
                else
                {
                    map.Add(s[j], j + 1);
                }
                
            }
            return ans;
        }
    }
}
