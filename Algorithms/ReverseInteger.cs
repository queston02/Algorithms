using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class ReverseInteger
    {
        static void Main()
        {
            Console.WriteLine(Reverse(123));
            Console.WriteLine(Reverse(-123));
            Console.WriteLine(Reverse(120));
            Console.WriteLine(Reverse(1534236469));
            Console.WriteLine(Reverse(1563847412));
        }

        static int Reverse(int x)
        {
            var result = 0;
            while (x != 0)
            {
                var reminder = x % 10;
                x = x / 10;
                if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && reminder > 7)) return 0;
                if (result < int.MinValue / 10 || (result == int.MinValue / 10 && reminder < -8)) return 0;
                result = result * 10 + reminder;
            }

            return result;
        }

        static int ReverseBin(int x)
        {
            var intList = new List<int>();
            while (x != 0)
            {
                var reminder = x % 10;
                intList.Add(reminder);
                x = x / 10;
            }
            try
            {
                var result = 0;
                for (var i = 0; i < intList.Count; i++)
                {
                    var multiplier = (int)Math.Pow(10, intList.Count - i - 1);
                    if (multiplier == 1000000000 && (intList[i] > 2 || intList[i] < -2))
                        return 0;
                    if (result > 0 && int.MaxValue - result < intList[i] * multiplier)
                        return 0;
                    if (result < 0 && int.MinValue - result > intList[i] * multiplier)
                        return 0;
                    result += intList[i] * multiplier;
                }
                return result;
            }
            catch
            {
                return 0;
            }
        }
    }
}
