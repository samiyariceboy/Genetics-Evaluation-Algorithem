using knapsackEvolutionALgorithm.Service.Entities.Common;
using knapsackEvolutionALgorithm.Service.Entities.Functions.Handler.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Entities.Functions.Handler
{
    public class FunctionsHnandler : IFunctionHandler<MinFuncIndividual, MinFuncIndividual>
    {
        private IList<object> _functionRequestList = new List<object>();

        public FunctionsHnandler(IList<object> functionRequestList)
        {
            _functionRequestList = functionRequestList;
        }

        public async Task<MinFuncIndividual> ProcessHandleFitness(MinFuncIndividual individual, int chromosomeLength, FunctionSelected function)
        {
            foreach (IFunction functionRequest in _functionRequestList)
            {
                var result = await functionRequest.HandleFitness(individual, chromosomeLength, function);
                if (result is MinFuncIndividual && result.Generate != null)
                {
                    return result;
                }
            }
            return null;
        }

        public async Task<MinFuncIndividual> ProcessHanldeExcutedFitness(MinFuncIndividual fitnessIndividual, FunctionSelected function)
        {
            foreach (IFunction functionRequest in _functionRequestList)
            {
                var result = await functionRequest.ExcutedFitness(fitnessIndividual, function);
                if (result is MinFuncIndividual && result.Generate != null)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
