using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class ContainerWithMostWater
    {
        static void Main()
        {
            Console.WriteLine(MaxArea(new int[] {1, 8, 6, 2, 5, 4, 8, 3, 7}));
        }

        private static int MaxArea(int[] height)
        {
            var maxArea = 0;
            var l = 0;
            var r = height.Length - 1;

            while (l != r)
            {
                var len = r - l;
                var width = Math.Min(height[l], height[r]);
                maxArea = Math.Max(maxArea, len * width);
                
                if (height[l] > height[r])
                    r--;
                else
                    l++;
            }

            return maxArea;
        }

        private static int MaxAreaBin(int[] height)
        {
            var maxArea = 0;

            for (int i = 0; i < height.Length - 1; i++)
            {
                for (int j = 1; j < height.Length; j++)
                {
                    var len = j - i;
                    var width = Math.Min(height[i], height[j]);
                    maxArea = Math.Max(maxArea, len * width);
                }
            }

            return maxArea;
        }
    }
}
