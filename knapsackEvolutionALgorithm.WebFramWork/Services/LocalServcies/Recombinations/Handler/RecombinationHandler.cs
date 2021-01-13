using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Recombinations.Handler.Interfaces;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Recombinations.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Recombinations.Handler
{
    public class RecombinationHandler : IRecombinationHandler<MinFuncIndividual, MinFuncIndividual>
    {
        private IList<object> _recombinationRequestList = new List<object>();

        public RecombinationHandler(IList<object> recombinationRequestList)
        {
            _recombinationRequestList = recombinationRequestList;
        }

        public async Task<(MinFuncIndividual first, MinFuncIndividual second)> ProcessRecombinationHandler(MinFuncIndividual parent1, MinFuncIndividual parent2, Recombination recombination)
        {
            //var threadId = Thread.CurrentThread.ManagedThreadId;
            foreach (IRecombinationMethod<MinFuncIndividual, MinFuncIndividual> recombinationRequest in _recombinationRequestList)
            {
                var result = await recombinationRequest.HandleRecombination(parent1, parent2, recombination);
                if (result is (MinFuncIndividual, MinFuncIndividual) && 
                    result.first.Generate != null && result.second.Generate != null )
                {
                    return (result.first, result.second);
                }
            }
            return (null, null);
        }
    }
}
