using knapsackEvolutionALgorithm.Service.Entities.Common;
using System;

namespace knapsackEvolutionALgorithm.Service.Entities.Functions
{
    public class Function2 : IFunction
    {
        #region Properties and Fields
        private readonly int _a;
        private readonly int _b;
        private readonly int _c;
        #endregion

        #region Ctors
        public Function2(int a, int b, int c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        #endregion
        public double Implement(MinFuncIndividual individual, int chromosomeLength)   
        {

            return _a * Math.Exp(_b * SQRT1(individual)) - Math.Exp(PART2(individual));
            #region nested Method
            double SQRT1(MinFuncIndividual individual)
            {
                var s = 0.0;
                foreach (var x in individual.Generate)
                    s += Math.Pow(x, 2);
                return Math.Sqrt((1 / chromosomeLength) * s);
            }
            double PART2(MinFuncIndividual individual)
            {
                var s = 0.0;
                foreach (var x in individual.Generate)
                    s += Math.Cos(_c * x);
                return ((1/ chromosomeLength) * s);
            }
            #endregion
        }

        public MinFuncIndividual HandleFitness(MinFuncIndividual individual, int chromosomeLength)
        {
            var result = Implement(individual, chromosomeLength);
            individual.Fitness = result;
            return individual;
        }

        public void LoadFunction()
        {

        }

    }
}
