using System;

namespace LearnYard.Puzzles
{
    public static class PuzzlesRunner
    {
        public static void RunLargestPuddleInABarChart()
        {
            var puddleBarChart = new LargestPuddleBarChart();
            Console.WriteLine("Largest pool size is {0}", puddleBarChart.GetLargestPuddleArea());
        }
    }
}
