using knapsackEvolutionALgorithm.Service.Entities.Common;
using System;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Entities.Functions
{
    public class Function3 : IFunction
    {
        #region Properties

        #endregion
        #region Ctors
        public Function3()
        {
        }


        #endregion
        public double Implement(MinFuncIndividual individual, int nCount)
        {
            var s = 0.0;
            foreach (var x in individual.Generate)
            {
                if (x > 5.12 || x < -5.12)
                    s += (10 * Math.Pow(x, 2));
                else if (x >= -5.12 && x <= 5.12)
                    s += (Math.Pow(x, 2) - (10 * Math.Cos(2 * Math.PI * x)));
            }
            return (10 * nCount) + s;
        }
        public Task<MinFuncIndividual> HandleFitness(MinFuncIndividual individual, int chromosomeLength, FunctionSelected functionSelected)
        {
            if (functionSelected == FunctionSelected.Function3)
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
            if (functionSelected == FunctionSelected.Function3)
            {
                individual.Fitness = 10000 - individual.Fitness;
                return Task.FromResult(individual);
            }
            return Task.FromResult(new MinFuncIndividual(null));
        }
    }
}
