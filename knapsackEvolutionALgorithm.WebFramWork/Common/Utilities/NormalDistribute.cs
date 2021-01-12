using System;

namespace knapsackEvolutionALgorithm.Service.Common.Utilities
{
    public static class NormalDistribute
    {
        public static double DoWork(double mu, double sigma)
        {
            var rabdom = new Random();
            /*double u = 0.0, v = 0.0;
            while (u == 0.0)
                u = RandomHelper.CreateRandom(0.0, 1.0);
            while (v == 0.0)
                v = RandomHelper.CreateRandom(0.0, 1.0);
            return mu + (sigma * (Math.Sqrt(-2.0 * Math.Log(u)) * Math.Cos(2.0 * Math.PI * v) ));*/
            return Math.Cos(2 * Math.PI * rabdom.NextDouble()) * Math.Sqrt(-2 * Math.Log(rabdom.NextDouble()));
        }
    }
}
