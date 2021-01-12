using System;

namespace knapsackEvolutionALgorithm.Service.Common.Utilities
{
    public static class RandomHelper
    {
        public static int CreateRandom(int maxValue)
        {
            var random = new Random();
            return random.Next(maxValue);
        }

        public static int CreateRandom(int minValue, int maxValue)
        {
            var random = new Random();
            return random.Next(minValue, maxValue);
        }

        public static double CreateRandom(double minValue, double maxValue)
        {
            var random = new Random();
            return random.NextDouble() * (maxValue - minValue);
        }
    }
}
