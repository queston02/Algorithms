using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class ZigZagConversion
    {
        static void Main()
        {
            Console.WriteLine(Convert("PAYPALISHIRING", 0));
            Console.WriteLine(Convert("PAYPALISHIRING", 1));
            Console.WriteLine(Convert("PAYPALISHIRING", 2));
            Console.WriteLine(Convert("PAYPALISHIRING", 3));
            Console.WriteLine(Convert("PAYPALISHIRING", 4));
            Console.WriteLine(Convert("PAYPALISHIRING", 14));
        }

        private static string Convert(string s, int numRows)
        {
            if (numRows == 1) return s;

            StringBuilder ret = new StringBuilder();
            int n = s.Length;
            int cycleLen = 2 * numRows - 2;

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j + i < n; j += cycleLen)
                {
                    ret.Append(s[j + i]);
                    if (i != 0 && i != numRows - 1 && j + cycleLen - i < n)
                        ret.Append(s[j + cycleLen - i]);
                }
            }
            return ret.ToString();
        }

        private static string ConvertBin(string s, int numRows)
        {
            var maxIndex = numRows - 1;
            if (maxIndex < 0)
                return string.Empty;
            var currentIndex = 0;
            var stringArray = new string[numRows];
            var forward = true;
            for (var i = 0; i < s.Length; i++)
            {
                stringArray[currentIndex] = stringArray[currentIndex] + s[i];

                if (currentIndex == maxIndex)
                    forward = false;
                if(currentIndex == 0)
                    forward = true;

                if (maxIndex == 0)
                    currentIndex = 0;
                else if (forward)
                    currentIndex += 1;
                else
                    currentIndex -= 1;
            }

            return String.Join(string.Empty, stringArray);
        }
    }
}
