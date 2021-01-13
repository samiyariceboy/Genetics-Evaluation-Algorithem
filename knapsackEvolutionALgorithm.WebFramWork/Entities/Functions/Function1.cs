using knapsackEvolutionALgorithm.Service.Entities.Common;
using System;
using System.Threading.Tasks;

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


        public Task<MinFuncIndividual> HandleFitness(MinFuncIndividual individual, int chromosomeLength, FunctionSelected functionSelected)
        {
            if (functionSelected == FunctionSelected.Function1)
            {
                double result = 0.0;
                result = Implement(individual, chromosomeLength);
                individual.Fitness = result;
                return Task.FromResult(individual);
            }
            return Task.FromResult(new MinFuncIndividual(null));
        }
        #endregion
        public double Implement(MinFuncIndividual individual, int nCount)
        {
            var s = 0.0;
            foreach (var x in   individual.Generate)
                s += (Math.Pow(x, 2) - (_a * Math.Cos(2 * (Math.PI) * x)));
            return 1000 - (s + (_a * nCount));
        }

        public Task<MinFuncIndividual> ExcutedFitness(MinFuncIndividual individual, FunctionSelected functionSelected)
        {
            if (functionSelected == FunctionSelected.Function1)
            {
                individual.Fitness = 1000 - individual.Fitness;
                return  Task.FromResult(individual);
            }
            return Task.FromResult(new MinFuncIndividual(null));
        }
    }
}
