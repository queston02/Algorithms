using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class MedianofTwoSortedArrays
    {
        static void Main()
        {
            var nums1 = new int[100000000];
            var nums2 = new int[100000000];

            for (int i = 0; i < 100000000; i++)
            {
                nums1[i] = i;
                nums2[i] = i;
            }
            Console.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));
            Console.WriteLine(FindMedianSortedArrays(nums1, nums2));
            Console.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));
            Console.WriteLine(FindMedianSortedArraysBin(nums1, nums2));
            Console.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));
        }

        private static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var m = nums1.Length;
            var n = nums2.Length;
            if (m > n)
            {
                var temp = nums1;
                nums1 = nums2;
                nums2 = temp;
                m = nums1.Length;
                n = nums2.Length;
            }

            var min = 0;
            var max = m;

            while (min <= max)
            {
                var i = (min + max) / 2;
                var j = ((m + n + 1) / 2) - i;

                if (i < max && nums1[i] < nums2[j - 1])
                {
                    min = i + 1;
                }
                else if(i > min && nums2[j] < nums1[i - 1])
                {
                    max = i - 1;
                }
                else
                {
                    int maxLeft;
                    int minRight;
                    if (i == 0)
                        maxLeft = nums2[j - 1];
                    else if (j == 0)
                        maxLeft = nums1[i - 1];
                    else
                        maxLeft = Math.Max(nums1[i - 1], nums2[j - 1]);

                    if ((m + n) % 2 == 1)
                        return maxLeft;

                    if (i == m)
                        minRight = nums2[j];
                    else if (j == n)
                        minRight = nums1[i];
                    else
                        minRight = Math.Min(nums1[i], nums2[j]);

                    return (double)(maxLeft + minRight) / 2;
                }
            }

            return 0.0;
        }

        private static double FindMedianSortedArraysBin(int[] nums1, int[] nums2)
        {
            var totalLength = nums1.Length + nums2.Length;

            int[] sortedArray;
            if (nums1.Length == 0)
            {
                sortedArray = nums2;
            }
            else if (nums2.Length == 0)
            {
                sortedArray = nums1;
            }
            else
            {
                sortedArray = SortedArray(nums1, nums2);
            }

            var midIndex = totalLength / 2 - 1;
            if (totalLength % 2 == 0)
            {
                return (sortedArray[midIndex] + sortedArray[midIndex + 1]) / (double)2;
            }
            else
            {
                return sortedArray[midIndex + 1];
            }
        }

        private static int[] SortedArray(int[] nums1, int[] nums2)
        {
            var num1Mid = nums1.Length / 2 + nums1.Length % 2;
            var num1MidIndex = 0 + num1Mid - 1;
            var num1Value = nums1[num1MidIndex];

            var num2MidIndex = SplitArray(num1Value, nums2, 0, nums2.Length - 1);

            if (num2MidIndex == -1)
            {
                var list = new List<int>();

                if (nums1.Length > 1)
                {
                    var newNum11 = new int[num1MidIndex + 1];
                    Array.Copy(nums1, newNum11, num1MidIndex + 1);

                    var newNum12 = new int[nums1.Length - num1MidIndex - 1];
                    Array.Copy(nums1, num1MidIndex + 1, newNum12, 0, nums1.Length - num1MidIndex - 1);

                    list.AddRange(newNum11);
                    list.AddRange(SortedArray(newNum12, nums2));
                }
                else
                {
                    list.AddRange(nums1);
                    list.AddRange(nums2);
                }

                return list.ToArray();
            }
            else if (num2MidIndex == nums2.Length - 1)
            {
                var list = new List<int>();

                if (nums1.Length > 1)
                {
                    var newNum11 = new int[num1MidIndex + 1];
                    Array.Copy(nums1, newNum11, num1MidIndex + 1);

                    var newNum12 = new int[nums1.Length - num1MidIndex - 1];
                    Array.Copy(nums1, num1MidIndex + 1, newNum12, 0, nums1.Length - num1MidIndex - 1);

                    list.AddRange(SortedArray(newNum11, nums2));
                    list.AddRange(newNum12);
                }
                else
                {
                    list.AddRange(nums2);
                    list.AddRange(nums1);
                }

                return list.ToArray();
            }
            else
            {
                var list = new List<int>();

                if (nums1.Length == 1)
                {
                    var newNum21 = new int[num2MidIndex + 1];
                    Array.Copy(nums2, newNum21, num2MidIndex + 1);

                    var newNum22 = new int[nums2.Length - num2MidIndex - 1];
                    Array.Copy(nums2, num2MidIndex + 1, newNum22, 0, nums2.Length - num2MidIndex - 1);

                    list.AddRange(newNum21);
                    list.AddRange(nums1);
                    list.AddRange(newNum22);
                }
                else
                {
                    var newNum11 = new int[num1MidIndex + 1];
                    Array.Copy(nums1, newNum11, num1MidIndex + 1);

                    var newNum12 = new int[nums1.Length - num1MidIndex - 1];
                    Array.Copy(nums1, num1MidIndex + 1, newNum12, 0, nums1.Length - num1MidIndex - 1);

                    var newNum21 = new int[num2MidIndex + 1];
                    Array.Copy(nums2, newNum21, num2MidIndex + 1);

                    var newNum22 = new int[nums2.Length - num2MidIndex - 1];
                    Array.Copy(nums2, num2MidIndex + 1, newNum22, 0, nums2.Length - num2MidIndex - 1);

                    list.AddRange(SortedArray(newNum11, newNum21));
                    list.AddRange(SortedArray(newNum12, newNum22));
                }

                return list.ToArray();
            }
        }

        private static int SplitArray(double splitValue, int[] nums2, int num2Start, int num2End)
        {
            var num2SubLength = num2End - num2Start + 1;
            var num2Mid = num2SubLength / 2 + num2SubLength % 2;
            var num2MidIndex = num2Start + num2Mid - 1;
            var num2Value = nums2[num2MidIndex];

            if (splitValue > num2Value)
            {
                if (num2MidIndex < num2End)
                    return SplitArray(splitValue, nums2, num2MidIndex + 1, num2End);
                else
                    return num2MidIndex;
            }
            else
            {
                if (num2MidIndex > num2Start)
                    return SplitArray(splitValue, nums2, num2Start, num2MidIndex - 1);
                else
                    return num2MidIndex - 1;
            }
        }
    }
}
