using knapsackEvolutionALgorithm.Service.Entities;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Recombinations.Handler.Interfaces
{
    public interface IRecombinationHandler<TRequest, TResult>
    {
        Task<(TResult first, TResult second)> ProcessRecombinationHandler(TRequest parent1, TRequest parent2, Recombination recombination);
    }
}
