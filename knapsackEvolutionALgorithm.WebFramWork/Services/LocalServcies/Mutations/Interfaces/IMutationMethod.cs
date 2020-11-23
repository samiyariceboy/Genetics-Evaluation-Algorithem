using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Mutations.Interfaces
{
    public interface IMutationMethod<in TSource, TResult>
        where TResult : class
        where TSource : class
    {
        TResult HandleMutation(TSource input);
    }
}
