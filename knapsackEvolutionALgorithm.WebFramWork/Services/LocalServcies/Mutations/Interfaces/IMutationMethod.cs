using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Mutations.Interfaces
{
    public interface IMutationMethod<in TSource, TResult>
        where TResult : class
        where TSource : class
    {
        Task<TResult> HandleMutation(TSource input);
    }

    public interface IEsMutationMethod<in TSource, TResult> : IMutationMethod<TSource, TResult>
        where TResult : class
        where TSource : class
    {
        Task UpdateCase(TSource oldSource, TSource newSource);

        /// <summary>
        /// for example Sigma
        /// </summary>
        /// <returns></returns>
        Task UpdateStatus();
    }
}
