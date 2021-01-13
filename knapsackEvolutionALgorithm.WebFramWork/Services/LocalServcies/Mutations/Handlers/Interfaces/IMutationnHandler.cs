using knapsackEvolutionALgorithm.Service.Entities;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Mutations.Handlers.Interfaces
{
    public interface IMutationnHandler<TRequest, TResult>
    {
        Task<TResult> ProcessMutationHandler(TRequest individual, Mutation mutation);
        Task<bool> ProcessUpdateCase(TRequest oldIndividual, TRequest newIndividual, Mutation mutation);
        Task<bool> ProcessUpdateStatus(Mutation mutation);
    }
}
