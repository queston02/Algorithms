using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    class RegularExpressionMatching
    {
        static void Main()
        {
            Console.WriteLine(IsMatch("ab", "a*b"));
            Console.WriteLine(IsMatch("aabcbcbcaccbcaabc", ".*a*aa*.*b*.c*.*a*"));
            Console.WriteLine(IsMatch("aasdfasdfasdfasdfas", "aasdf.*asdf.*asdf.*asdf.*s"));
            Console.WriteLine(IsMatch("", "."));
            Console.WriteLine(IsMatch("mississippi", "mis*is*ip*."));
            Console.WriteLine(IsMatch("bcaaaabc", "bca*aac*bc"));
            Console.WriteLine(IsMatch("ab", ".*.."));
            Console.WriteLine(IsMatch("a", ".*..a*"));
            Console.WriteLine(IsMatch("a", "ab*a"));
            Console.WriteLine(IsMatch("aaa", "aaaa"));
            Console.WriteLine(IsMatch("abcd", "d*"));
            Console.WriteLine(IsMatch("a", "ab*"));
            Console.WriteLine(IsMatch("aaa", "a*a"));
            Console.WriteLine(IsMatch("aa", "a"));
            Console.WriteLine(IsMatch("aa", "a*"));
            Console.WriteLine(IsMatch("ab", ".*"));
            Console.WriteLine(IsMatch("ab", ".*c"));
            Console.WriteLine(IsMatch("aab", "c*a*b"));
            Console.WriteLine(IsMatch("mississippi", "mis*is*p*."));
        }

        private static bool IsMatch(string text, string pattern)
        {
            bool[,] dp = new bool[text.Length + 1, pattern.Length + 1];
            dp[0, 0] = true;

            for (int j = 1; j < pattern.Length + 1; j++)
            {
                if (pattern[j - 1] == '*')
                {
                    dp[0, j] = dp[0, j - 2];
                }
            }

            for (int i = 1; i < text.Length + 1; i++)
            {
                for (int j = 1; j < pattern.Length + 1; j++)
                {
                    if (text[i - 1] == pattern[j - 1] || pattern[j - 1] == '.')
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }

                    if (pattern[j - 1] == '*')
                    {
                        dp[i, j] = ((text[i - 1] == pattern[j - 2] || pattern[j - 2] == '.') && dp[i - 1, j]) || dp[i, j - 2];
                    }
                }
            }
            return dp[text.Length, pattern.Length];
        }

        private static bool IsMatchBin3(string text, string pattern)
        {
            bool[,] dp = new bool[text.Length + 1, pattern.Length + 1];
            dp[text.Length, pattern.Length] = true;

            for (int i = text.Length; i >= 0; i--)
            {
                for (int j = pattern.Length - 1; j >= 0; j--)
                {
                    bool first_match = (i < text.Length &&
                                           (pattern[j] == text[i] ||
                                            pattern[j] == '.'));
                    if (j + 1 < pattern.Length && pattern[j + 1] == '*')
                    {
                        dp[i, j] = dp[i, j + 2] || first_match && dp[i + 1, j];
                    }
                    else
                    {
                        dp[i, j] = first_match && dp[i + 1, j + 1];
                    }
                }
            }
            return dp[0, 0];
        }

        private static bool IsMatchBin(string s, string p)
        {
            if (p == string.Empty)
                return s == string.Empty;

            bool firstMatch = s != string.Empty && (s[0] == p[0] || p[0] == '.');

            if (p.Length >= 2 && p[1] == '*')
                return (firstMatch && IsMatch(s.Substring(1), p)) || IsMatch(s, p.Substring(2));
            else
                return firstMatch && IsMatch(s.Substring(1), p.Substring(1));
        }

        private static bool IsMatchBin2(string s, string p)
        {
            bool?[,] memo;
            memo = new bool?[s.Length + 1, p.Length + 1];
            return Dp(0, 0, s, p, memo);
        }

        private static bool Dp(int i, int j, string s, string p, bool?[,] memo)
        {
            if (memo[i, j] != null)
            {
                return memo[i, j].Value;
            }

            if (j >= p.Length)
                memo[i, j] = i >= s.Length;
            else
            {
                var firstMatch = i < s.Length && (s[i] == p[j] || p[j] == '.');

                if (j + 1 < p.Length && p[j + 1] == '*')
                {
                    memo[i, j] = (firstMatch && Dp(i + 1, j, s, p, memo)) || Dp(i, j + 2, s, p, memo);
                }
                else
                {
                    memo[i, j] = firstMatch && Dp(i + 1, j + 1, s, p, memo);
                }
            }

            return memo[i, j].Value;
        }
    }
}
