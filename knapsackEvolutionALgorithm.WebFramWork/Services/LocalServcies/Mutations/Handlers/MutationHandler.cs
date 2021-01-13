using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Mutations.Handlers.Interfaces;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Mutations.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Mutations.Handlers
{
    public class MutationHandler : IMutationnHandler<MinFuncIndividual, MinFuncIndividual>
    {
        private IList<object> _mutationRequestList = new List<object>();

        public MutationHandler(IList<object> mutationRequestList)
        {
            _mutationRequestList = mutationRequestList;
        }
        public async Task<MinFuncIndividual> ProcessMutationHandler(MinFuncIndividual individual, Mutation mutation)
        {
            foreach (IEsMutationMethod<MinFuncIndividual, MinFuncIndividual> mutationRequest in _mutationRequestList)
            {
                var result = await mutationRequest.HandleMutation(individual, mutation);
                if (result is MinFuncIndividual &&
                    result != individual)
                {
                    return result;
                }
            }
            return null;
        }

        public async Task<bool> ProcessUpdateCase(MinFuncIndividual oldIndividual, MinFuncIndividual newIndividual, Mutation mutation)
        {
            foreach (IEsMutationMethod<MinFuncIndividual, MinFuncIndividual> mutationRequest in _mutationRequestList)
            {
                if (await mutationRequest.UpdateCase(oldIndividual, newIndividual, mutation) is true)
                    return true;
            }
            return false;
        }

        public async Task<bool> ProcessUpdateStatus(Mutation mutation)
        {
            foreach (IEsMutationMethod<MinFuncIndividual, MinFuncIndividual> mutationRequest in _mutationRequestList)
            {
                if (await mutationRequest.UpdateStatus(mutation) is true)
                    return true;
            }
            return false;
        }
    }
}
