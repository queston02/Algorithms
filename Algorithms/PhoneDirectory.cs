using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    class PhoneDirectory
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
                var searchText = testCasesSearchData[i];

                SearchText(searchText, 0, text.ToList());
            }
        }

        static void SearchText(string text, int index, List<string> stringList)
        {
            var remainingString = new List<string>();

            foreach (var name in stringList)
            {
                if (index < name.Length && name[index] == text[index])
                {
                    remainingString.Add(name);
                }
            }

            if (remainingString.Any())
            {
                Console.WriteLine(string.Join(" ", remainingString));
            }
            else
            {
                Console.WriteLine("0");
            }

            index += 1;

            if(index < text.Length)
                SearchText(text, index, remainingString);
        }
    }
}