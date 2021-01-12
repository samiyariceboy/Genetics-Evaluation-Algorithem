using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections.Handlers.Interfaces
{
    public interface ISelectionHandler
    {
        Task ProcessSelection(ISelectionMethod<IList<MinFuncIndividual>, IList<MinFuncIndividual>> selectionMethod);
    }
}
