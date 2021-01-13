using knapsackEvolutionALgorithm.Service.Entities.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Entities.Functions.Handler.Interfaces
{
    public interface IFunctionHandler<in TRequest, TResult>
    {
        Task<TResult> ProcessHandleFitness(TRequest infividual, int chromosomeLength, FunctionSelected function);
        Task<TResult> ProcessHanldeExcutedFitness(TRequest fitness, FunctionSelected function);
    }
}
