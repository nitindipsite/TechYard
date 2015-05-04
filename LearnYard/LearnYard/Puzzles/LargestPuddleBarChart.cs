using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnYard.Puzzles
{
    public class LargestPuddleBarChart
    {
        private readonly int[] _barChart;
        private static int MaxPuddleSize;

        public LargestPuddleBarChart()
        {
            //_barChart = new[] { 10, 20, 80, 70, 60, 90, 40, 30, 40, 70 };
            //_barChart = new[] {40, 10, 60, 40, 20, 80,60, 40, 20, 70, 60};
            //_barChart = new[] { 120, 90, 40, 10, 40 };
            _barChart = new[] { 120, 90, 40, 30,10};
        }

        /*
            1. Anytime we have a higher bar followed by a lower bar, a puddle can start.
         *  2. Puddle is created when we have shorter bars trapped between 2 longest bar, one on each side.
         */
        public int GetLargestPuddleArea()
        {
            int currentPuddleSize, maxPuddleSize = 0;
            int puddleStartIndex, puddleEndIndex = -1;

            for (int i = 0; i < _barChart.Length - 2; i++)
            {
                if (_barChart[i] > _barChart[i + 1])
                {
                    puddleStartIndex = i;
                    // Get the puddle end, if there is one.
                    puddleEndIndex = GetPuddleEnd(puddleStartIndex);
                    // Get the puddle area.
                    if (puddleEndIndex != -1)
                    {
                        currentPuddleSize = GetPuddleArea(puddleStartIndex, puddleEndIndex);
                        maxPuddleSize = currentPuddleSize > maxPuddleSize ? currentPuddleSize : maxPuddleSize;
                        i = puddleEndIndex - 1;
                    }
                }
            }
            return maxPuddleSize;
        }

        private int GetPuddleEnd(int puddleStartIndex)
        {
            int puddleEndIndex = -1;
            int puddleStartHeight = _barChart[puddleStartIndex];
            // 1. From left->right, if we find a taller bar than start height, we have a puddle.
            // 2. Else start from right->left and find the tallest bar shorter than start height.
            
            // 1.
            for (int i = puddleStartIndex + 1; i < _barChart.Length; i++)
            {
                if (_barChart[i] >= puddleStartHeight)
                {
                    // There should be a gap of atleast one.
                    if (i - puddleStartIndex > 1)
                    {
                        puddleEndIndex = i;
                        break;
                    }
                }
            }

            // 2.
            if (puddleEndIndex == -1)
            {
                int largestShorter = -1;
                int largestShorterIndex = _barChart.Length -1;
                for (int i = _barChart.Length -1; i > puddleStartIndex; i--)
                {
                    if (_barChart[i] < _barChart[puddleStartIndex])
                    {
                        if (largestShorter <= _barChart[i])
                        {
                            largestShorter = _barChart[i];
                            largestShorterIndex = i;
                        }
                    }
                }
                if (largestShorterIndex - puddleStartIndex > 1)
                {
                    puddleEndIndex = largestShorterIndex;
                }
            }

            return puddleEndIndex;
        }

        private int GetPuddleArea(int startIndex, int endIndex)
        {
            int puddleArea = 0;
            int puddleHeight = Math.Min(_barChart[startIndex], _barChart[endIndex]);
            for (int i = startIndex+1; i < endIndex; i++)
            {
                puddleArea += (puddleHeight - _barChart[i]);
            }
            Console.WriteLine("Puddle area between Index {0}({1}) and Index {2}({3}) is {4}", startIndex, _barChart[startIndex], endIndex, _barChart[endIndex], puddleArea);
            return puddleArea;
        }

    }
}
