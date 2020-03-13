using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    class MinimumCostOfRopes
    {
        static void Main()
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            Dictionary<int, string> testCasesData = new Dictionary<int, string>();
            
            for (int i = 0; i < numberOfTestCases; i++)
            {
                testCasesData[Convert.ToInt32(Console.ReadLine())] = Console.ReadLine();
            }

            foreach (var testCaseData in testCasesData)
            {
                var ropes = testCaseData.Value.Replace(" ",String.Empty).ToCharArray().Select(x => Convert.ToInt32(x.ToString())).ToList();
                
                Console.WriteLine(CalculateCost(0, ropes));
            }
        }

        static long CalculateCost(long cost, List<int> remainingRopes)
        {
            remainingRopes = remainingRopes.OrderBy(x => x).ToList();
            var newRope = remainingRopes[0] + remainingRopes[1];
            var newCost = cost + newRope;
            remainingRopes.RemoveRange(0,2);
            remainingRopes.Add(newRope);

            if (remainingRopes.Count > 1)
                return CalculateCost(newCost, remainingRopes);
            else
                return newCost;
        }
    }
}