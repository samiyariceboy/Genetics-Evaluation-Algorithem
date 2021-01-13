using knapsackEvolutionALgorithm.Service.Entities;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Recombinations.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface IRecombinationMethod<in TSource, TResult>
        where TResult : TSource
    {
        Task<(TResult first, TResult second)> HandleRecombination(TSource first, TSource second, Recombination recombination);
    }
}
