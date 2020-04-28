using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class MissingNumberInSortedArray
    {
        static void Main()
        {
            Console.WriteLine(FindMissing(new int[]{ 1, 2, 3, 4, 5, 6, 8 }));
            Console.WriteLine(FindMissing(new int[] { 1, 2, 3, 4, 5, 7, 8 }));
            Console.WriteLine(FindMissing(new int[] { 1, 2, 3, 4, 6, 7, 8 }));
            Console.WriteLine(FindMissing(new int[] { 1, 2, 3, 5, 6, 7, 8 }));
            Console.WriteLine(FindMissing(new int[] { 1, 2, 4, 5, 6, 7, 8 }));
            Console.WriteLine(FindMissing(new int[] { 1, 3, 4, 5, 6, 7, 8 }));
        }
        private static int FindMissing(int[] intArray)
        {
            var len = intArray.Length;
            var start = 0;
            var end = len - 1;
            while (start != end)
            {
                var mid = start + (end - start) / 2;
                var num = intArray[mid];
                if (num - mid == 1)
                    start = mid + 1;
                else
                    end = mid - 1;
            }

            return intArray[start] - start == 1 ? intArray[start] + 1 : intArray[start] - 1;
        }
    }
}
