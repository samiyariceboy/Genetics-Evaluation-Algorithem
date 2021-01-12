using knapsackEvolutionALgorithm.Service.Entities.Common;
using System;
namespace knapsackEvolutionALgorithm.Service.Entities.Functions
{
    public class Function1 : IFunction
    {
        #region Propertes
        private readonly int _a;
        #endregion
        #region Ctors

        public Function1(int a = 10)
        {
            _a = a;
        }

        public MinFuncIndividual HandleFitness(MinFuncIndividual individual, int chromosomeLength)
        {
            var result = Implement(individual, chromosomeLength);
            individual.Fitness = result;
            return individual;
        }
        #endregion
        public double Implement(MinFuncIndividual individual, int nCount)
        {
            var s = 0.0;
            foreach (var x in individual.Generate)
                s += (Math.Pow(x, 2) - (_a * Math.Cos(2 * (Math.PI) * x)));
            return (s + (_a * nCount));
        }

        public IFunction Select(FunctionSelected selected)
        {
            if (selected == FunctionSelected.Function1)
            {
                return this;
            }
            return null;
        }

    }
}
