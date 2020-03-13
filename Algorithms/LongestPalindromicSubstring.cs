using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class LongestPalindromicSubstring
    {
        static void Main()
        {
            Console.WriteLine(LongestPalindrome("a"));
            Console.WriteLine(LongestPalindrome("aa"));
            Console.WriteLine(LongestPalindrome("aaa"));
            Console.WriteLine(LongestPalindrome("aaaa"));
            Console.WriteLine(LongestPalindrome("aaabaaaa"));
            Console.WriteLine(LongestPalindrome("babad"));
            Console.WriteLine(LongestPalindrome("cbbd"));
            Console.WriteLine(LongestPalindrome("babab"));
            Console.WriteLine(LongestPalindrome("aaaabbbbbbbbbbccccccccccddddddddddeeeeeeeeeeffffffffffgggggggggghhhhhhhhhhiiiiiiiiiijjjjjjjjjjkkkkkkkkkkllllllllllmmmmmmmmmmnnnnnnnnnnooooooooooppppppppppqqqqqqqqqqrrrrrrrrrrssssssssssttttttttttuuuuuuuuuuvvvvvvvvvvwwwwwwwwwwxxxxxxxxxxyyyyyyyyyyzzzzzzzzzzyyyyyyyyyyxxxxxxxxxxwwwwwwwwwwvvvvvvvvvvuuuuuuuuuuttttttttttssssssssssrrrrrrrrrrqqqqqqqqqqppppppppppoooooooooonnnnnnnnnnmmmmmmmmmmllllllllllkkkkkkkkkkjjjjjjjjjjiiiiiiiiiihhhhhhhhhhggggggggggffffffffffeeeeeeeeeeddddddddddccccccccccbbbbbbbbbbaaaaaaaabbbbbbbbbbccccccccccddddddddddeeeeeeeeeeffffffffffgggggggggghhhhhhhhhhiiiiiiiiiijjjjjjjjjjkkkkkkkkkkllllllllllmmmmmmmmmmnnnnnnnnnnooooooooooppppppppppqqqqqqqqqqrrrrrrrrrrssssssssssttttttttttuuuuuuuuuuvvvvvvvvvvwwwwwwwwwwxxxxxxxxxxyyyyyyyyyyzzzzzzzzzzyyyyyyyyyyxxxxxxxxxxwwwwwwwwwwvvvvvvvvvvuuuuuuuuuuttttttttttssssssssssrrrrrrrrrrqqqqqqqqqqppppppppppoooooooooonnnnnnnnnnmmmmmmmmmmllllllllllkkkkkkkkkkjjjjjjjjjjiiiiiiiiiihhhhhhhhhhggggggggggffffffffffeeeeeeeeeeddddddddddccccccccccbbbbbbbbbbaaaa"));
        }

        private static string LongestPalindrome(string s)
        {
            int start = 0;
            int maxLen = 0;

            for (int i = 0; i < s.Length; i++)
            {
                var len1 = ExpandAroundCenter(s, i, i);
                var len2 = ExpandAroundCenter(s, i, i + 1);

                var len = Math.Max(len1, len2);
                if (len > maxLen)
                {
                    start = i - (len - 1) / 2;
                    maxLen = len;
                }
            }

            return s.Substring(start, maxLen);
        }

        private static int ExpandAroundCenter(string s, int l, int r)
        {
            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                l--;
                r++;
            }

            return r - l - 1;
        }
        private static string LongestPalindromeBin(string s)
        {
            var pdSubstring = string.Empty;

            for (int i = 0; i < s.Length; i++)
            {
                var keepGoing = true;
                var backStep = 1;
                var frontStep = 1;
                var tempPdString = s[i].ToString();
                var canMoveForward = true;
                while (keepGoing)
                {
                    var backIndex = i - backStep;
                    var frontIndex = i + frontStep;

                    if (frontIndex < s.Length)
                    {
                        var left = string.Empty;
                        if (backIndex >= 0)
                        {
                            left = s[backIndex].ToString();
                        }

                        var right = s[frontIndex];
                        if (right == s[frontIndex - 1] && canMoveForward)
                        {
                            tempPdString += right;
                            frontStep++;
                        }
                        else
                        {
                            if (left == right.ToString())
                            {
                                tempPdString = left + tempPdString + right;
                                backStep++;
                                frontStep++;
                                canMoveForward = false;
                            }
                            else
                            {
                                keepGoing = false;
                            }
                        }
                    }
                    else
                    {
                        keepGoing = false;
                    }
                }

                if (tempPdString.Length > pdSubstring.Length)
                {
                    pdSubstring = tempPdString;
                }

                if (i + frontStep == s.Length)
                {
                    break;
                }
            }

            return pdSubstring;
        }
    }
}
