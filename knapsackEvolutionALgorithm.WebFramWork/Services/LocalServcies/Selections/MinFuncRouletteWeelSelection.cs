using knapsackEvolutionALgorithm.Service.Common.Utilities;
using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections
{
    public class MinFuncRouletteWeelSelection
         : ISelectionMethod<IList<MinFuncIndividual>, IList<MinFuncIndividual>>
    {
        public MinFuncRouletteWeelSelection()
        {
        }
        public async Task<IList<MinFuncIndividual>> HandleSelection(IList<MinFuncIndividual> selectionBoxs, int numberOfSelection)
        {
            var selectiveIndividulas = new List<MinFuncIndividual>();
            var rouletteSelect = new List<double>();
            await Task.Run(() => 
            {
                for (int i = 0; i < selectionBoxs.Count(); i++)
                {
                    if (i == 0)
                        rouletteSelect.Add(selectionBoxs[i].Fitness);
                    else
                        rouletteSelect.Add(selectionBoxs[i-1].Fitness + selectionBoxs[i].Fitness);
                }
            });

            await Task.Run(() =>
            {
                for (int i = 0; i < numberOfSelection; i++)
                {
                    var random = RandomHelper.CreateRandom(0, rouletteSelect[selectionBoxs.Count() - 1]);
                    for (int j = 0; j < rouletteSelect.Count(); j++)
                    {
                        if (random >= rouletteSelect[j] && random < rouletteSelect[j+1])
                        {
                            selectiveIndividulas.Add(selectionBoxs[j]);
                            break;
                        }

                    }
                }
            });

            return selectiveIndividulas;

        }

    }
}
