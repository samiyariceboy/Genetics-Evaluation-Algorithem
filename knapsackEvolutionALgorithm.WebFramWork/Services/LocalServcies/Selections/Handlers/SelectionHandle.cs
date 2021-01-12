using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Interfaces;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections.Handlers.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections.Handlers
{
    public class SelectionHandle : ISelectionHandler
    {
        public Task ProcessSelection(ISelectionMethod<IList<MinFuncIndividual>, IList<MinFuncIndividual>> selectionMethod)
        {
            throw new System.NotImplementedException();
        }
    }
}
