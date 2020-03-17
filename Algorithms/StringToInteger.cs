using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class StringToInteger
    {
        static void Main()
        {
            Console.WriteLine(MyAtoi("42"));
            Console.WriteLine(MyAtoi("   -42"));
            Console.WriteLine(MyAtoi("4193 with words"));
            Console.WriteLine(MyAtoi("words and 987"));
            Console.WriteLine(MyAtoi("-91283472332"));
            Console.WriteLine(MyAtoi("+1"));
        }
        private static int MyAtoi(string str)
        {
            var isNegative = false;
            var result = 0;
            str = str.TrimStart(' ');
            for (int i = 0; i < str.Length; i++)
            {
                var isInt = int.TryParse(str[i].ToString(), out var subInt);

                if (!isInt && i == 0 && str[i] == '-')
                    isNegative = true;
                else if (!isInt && i == 0 && str[i] == '+')
                    isNegative = false;
                else if (!isInt && result != 0)
                    return result;
                else if (!isInt)
                    return 0;
                else
                {
                    if (isNegative)
                        subInt = -1 * subInt;
                    if (result > int.MaxValue / 10 || result == int.MaxValue / 10 && subInt > 7)
                        return int.MaxValue;
                    if (result < int.MinValue / 10 || result == int.MinValue / 10 && subInt < -8)
                        return int.MinValue;
                    result = result * 10 + subInt;
                }
            }
            return result;
        }
    }
}
