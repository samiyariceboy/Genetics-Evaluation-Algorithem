using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Recombinations.Interfaces
{
    public interface IRecombinationMethod<in TSource, TResult>
        where TResult : TSource
    {
        Task<(TResult first, TResult second)> HandleRecombination(TSource first, TSource second);
    }
}
