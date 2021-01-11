using knapsackEvolutionALgorithm.Service.Common.Utilities;
using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections
{
    public class MainFuncTournamentSelection
        : ISelectionMethod<IList<MinFuncIndividula>, IList<MinFuncIndividula>>
    {
        public async Task<IList<MinFuncIndividula>> HandleSelection(IList<MinFuncIndividula> SelectionBoxs, int capacity)
        {
            SelectionBoxs.OrderBy(O => O.Fitness);
            var rand = RandomHelper.CreateRandom(1, SelectionBoxs.);
        }
    }
}
