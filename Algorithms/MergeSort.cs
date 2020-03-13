using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Algorithms
{
    class MergeSort
    {
        static void Main(string[] args)
        {
            var arrayToBeSorted = new int[]
            {
                1, 5, 4, 11, 20, 8, 2, 98, 90, 16
            };
            var sortedArray = SortArray(arrayToBeSorted);
            Console.WriteLine(string.Join(',', sortedArray));
        }
        private static int[] SortArray(int[] intArray)
        {
            if (intArray.Length > 1)
            {
                var firstArrayLength = intArray.Length / 2;
                var secondArrayLength = intArray.Length - firstArrayLength;

                var firstArray = intArray.Take(firstArrayLength).ToArray();
                var secondArray = intArray.TakeLast(secondArrayLength).ToArray();

                var sortedFirstArray = SortArray(firstArray);
                var sortedSecondArray = SortArray(secondArray);

                return MergeAndSort(sortedFirstArray, sortedSecondArray);
            }
            else
            {
                return intArray;
            }
        }

        private static int[] MergeAndSort(int[] firstArray, int[] secondArray)
        {
            int[] mergedArray = new int[firstArray.Length + secondArray.Length];
            var i = 0;
            var j = 0;

            for (int k = 0; k < mergedArray.Length; k++)
            {
                if (i == firstArray.Length)
                {
                    mergedArray[k] = secondArray[j];
                    j += 1;
                }
                else if(j == secondArray.Length)
                {
                    mergedArray[k] = firstArray[i];
                    i += 1;
                }
                else if (firstArray[i] < secondArray[j])
                {
                    mergedArray[k] = firstArray[i];
                    i += 1;
                }
                else
                {
                    mergedArray[k] = secondArray[j];
                    j += 1;
                }
            }

            return mergedArray;
        }
    }
}
