using knapsackEvolutionALgorithm.Service.Entities;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections.Handlers.Interfaces
{
    public interface ISelectionHandler<TRequest, TResult>
        where TRequest : class
        where TResult : class
    {
        Task<TResult> ProcessingRandomSelection(TRequest selectionBox, int capacity, Selection selection);
        Task<TResult> ProcessSelection(TRequest selectionBox, int capacity, Selection selection);
    }
}
