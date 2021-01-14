using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Interfaces;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections.Handlers.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections.Handlers
{
    public class SelectionHandle : ISelectionHandler<IList<MinFuncIndividual>, IList<MinFuncIndividual>>
    {
        private IList<object> _selectionRequestList = new List<object>();

        public SelectionHandle(
                IList<object> selectionRequestList
            )
        {
            _selectionRequestList = selectionRequestList;
        }

        public Task<IList<MinFuncIndividual>> ProcessingRandomSelection(IList<MinFuncIndividual> selectionBox, int capacity, Selection selection)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<MinFuncIndividual>> ProcessSelection(IList<MinFuncIndividual> seletionBox, int capacity, Selection selection)
        {
            foreach (ISelectionMethod<IList<MinFuncIndividual>, IList<MinFuncIndividual>> selectionRequest in _selectionRequestList)
            {
                var result = await selectionRequest.HandleSelection(seletionBox, capacity, selection);
                if (result != null && result.Count() > 0 && result.First().Generate != null && result is IList<MinFuncIndividual> selectionResult)
                {
                    return selectionResult;
                }
            }
            return null;
        }
    }
}
