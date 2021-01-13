using knapsackEvolutionALgorithm.Service.Entities;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Mutations.Interfaces
{
    public interface IMutationMethod<in TSource, TResult>
        where TResult : class
        where TSource : class
    {
        Task<TResult> HandleMutation(TSource input, Mutation mutation);
    }

    public interface IEsMutationMethod<in TSource, TResult> : IMutationMethod<TSource, TResult>
        where TResult : class
        where TSource : class
    {
        Task<bool> UpdateCase(TSource oldSource, TSource newSource, Mutation mutation);

        /// <summary>
        /// for example Sigma
        /// </summary>
        /// <returns></returns>
        Task<bool> UpdateStatus(Mutation mutation);
    }
}
