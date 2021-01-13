using knapsackEvolutionALgorithm.Service.Entities.Common;
using System;
using System.Threading.Tasks;

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
            var sigma1 = 0.0;
            var sigma2 = 0.0;
            var fitness = 0.0;

            foreach (var x in individual.Generate)
            {
                sigma1 += (x * x);
                sigma2 += (Math.Cos(_c * x));
            }

            fitness = -_a * Math.Exp(-_b * Math.Sqrt(sigma1 / chromosomeLength)) - Math.Exp(sigma2 / chromosomeLength) + _a + Math.Exp(1);
            return 50 - fitness;
        }

        public Task<MinFuncIndividual> HandleFitness(MinFuncIndividual individual, int chromosomeLength, FunctionSelected functionSelected)
        {
            if (functionSelected == FunctionSelected.Function2)
            {
                double result = 0.0;
                result = Implement(individual, chromosomeLength);
                individual.Fitness = result;
                return Task.FromResult(individual);
            }
            return Task.FromResult(new MinFuncIndividual(null));
        }
        public Task<MinFuncIndividual> ExcutedFitness(MinFuncIndividual individual, FunctionSelected functionSelected)
        {
            if (functionSelected == FunctionSelected.Function2)
            {
                individual.Fitness = 50 - individual.Fitness;
                return Task.FromResult(individual);
            }
            return Task.FromResult(new MinFuncIndividual(null));
        }
    }
}
