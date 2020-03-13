using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    class Trie
    {
        static void Main()
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            List<string> testCasesData = new List<string>();
            List<string> testCasesSearchData = new List<string>();

            for (int i = 0; i < numberOfTestCases; i++)
            {
                Console.ReadLine();
                testCasesData.Add(Console.ReadLine());
                testCasesSearchData.Add(Console.ReadLine());
            }

            for (var i = 0; i < testCasesData.Count; i++)
            {
                var text = testCasesData[i].Split(" ");

                if (text.Contains(testCasesSearchData[i]))
                {
                    Console.WriteLine("1");
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
        }
    }
}
