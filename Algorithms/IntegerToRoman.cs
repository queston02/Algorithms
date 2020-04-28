using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class IntegerToRoman
    {
        static void Main()
        {
            Console.WriteLine(IntToRoman(3999));
        }
        static string IntToRoman(int num)
        {
            var i = 0;
            var result = string.Empty;

            while (num > 0)
            {
                var den = num % 10;
                num = num / 10;

                den = den * (int)Math.Pow(10, i);

                if (den > 0 && den < 4)
                {
                    var count = den / 1;
                    result = count == 3 ? "III" : count == 2 ? "II" : "I";
                }
                else if (den == 4)
                {
                    result = "IV";
                }
                else if(den == 5)
                {
                    result = "V";
                }
                else if(den > 5 && den < 9)
                {
                    var count = (den - 5) / 1;
                    result = "V" + (count == 3 ? "III" : count == 2 ? "II" : "I");
                }
                else if(den == 9)
                {
                    result = "IX";
                }
                else if (den == 10)
                {
                    result = "X" + result;
                }
                else if (den > 10 && den < 40)
                {
                    var count = den / 10;
                    result = (count == 3 ? "XXX" : "XX") + result;
                }
                else if (den == 40)
                {
                    result = "XL" + result;
                }
                else if(den == 50)
                {
                    result = "L" + result;
                }
                else if(den > 50 && den < 90)
                {
                    var count = (den - 50) / 10;
                    result = "L" + (count == 3 ? "XXX" : count == 2 ? "XX" : "X") + result;
                }
                else if (den == 90)
                {
                    result = "XC" + result;
                }
                else if(den == 100)
                {
                    result = "C" + result;
                }
                else if(den > 100 && den < 400)
                {
                    var count = den / 100;
                    result = (count == 3 ? "CCC" : "CC") + result;
                }
                else if (den == 400)
                {
                    result = "CD" + result;
                }
                else if (den == 500)
                {
                    result = "D" + result;
                }
                else if(den > 500 && den < 900)
                {
                    var count = (den - 500) / 100;
                    result = "D" + (count == 3 ? "CCC" : count == 2 ? "CC" : "C") + result;
                }
                else if (den == 900)
                {
                    result = "CM" + result;
                }
                else if(den == 1000)
                {
                    result = "M" + result;
                }
                else if(den > 1000)
                {
                    var count = den / 1000;
                    result = (count == 3 ? "MMM" : "MM") + result;
                }

                i++;
            }

            return result;
        }
    }
}
