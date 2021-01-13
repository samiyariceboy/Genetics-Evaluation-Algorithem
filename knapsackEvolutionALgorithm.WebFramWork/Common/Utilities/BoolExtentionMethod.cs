using System;
using System.Linq;

namespace knapsackEvolutionALgorithm.Service.Common.Utilities
{
    public static class BoolExtentionMethod
    {
        public static bool[] GenerateRandom(this bool[] input)
        {
            var random = new Random();
            for (int i = 0; i < input.Count(); i++)
                input[i] = random.Next(0, 2) == 1 ? true : false;
            return input;
        }
    }

    public static class DoubleExtentionMethod
    {
        public static double[] GenerateRandom(this double[] input)
        {
            var random = new Random();
            for (int i = 0; i < input.Count(); i++)
                input[i] = (RandomHelper.CreateRandom01());
            return input;
        }
    }

}
