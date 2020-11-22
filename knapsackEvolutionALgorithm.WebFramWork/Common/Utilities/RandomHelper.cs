using System;

namespace knapsackEvolutionALgorithm.Service.Common.Utilities
{
    public static class RandomHelper
    {
        public static int CreateRandom(int minValue, int maxValue)
        {
            var random = new Random();
            return random.Next(minValue, maxValue);
        }
    }
}
