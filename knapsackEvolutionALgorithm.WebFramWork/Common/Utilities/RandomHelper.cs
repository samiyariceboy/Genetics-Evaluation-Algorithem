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
            var ranomdCorrect = random.Next(Convert.ToInt32(minValue.ToString()),  int.Parse(Math.Ceiling(maxValue).ToString()));
            var randomReal = random.Next(0, int.MaxValue);
            var generateNumber = $"{ranomdCorrect}.{randomReal}";
            return double.Parse(generateNumber);
        }

        public static double CreateRandom01()
        {
            var random = new Random();
            var ranomd1 = random.Next(0, int.MaxValue);
            var randomGenerator = double.Parse($"0.{ranomd1}");
            return randomGenerator;
        }

        public static double CreateDoubleRandom()
        {
            var random = new Random();
            return random.NextDouble();
        }
    }
}
