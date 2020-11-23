using knapsackEvolutionALgorithm.Service.Common.Utilities;
using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections
{
    public class RouletteWeelSelection
        : ISelectionMethod<IList<Individual>,
            IList<Individual>>
    {
        public void Dispose()
        {
            Dispose();
        }

        public async Task<IList<Individual>> HandleSelection(IList<Individual> SelectionBoxs, int capacity)
        {
            var totalRoulet = 0;
            var selection = new List<Individual>();
            await Task.Run(() =>
            {
                for (int i = 0; i < SelectionBoxs.Count; i++)
                    totalRoulet += SelectionBoxs[i].Fitness;
            });

            await Task.Run(() =>
            {
                while (capacity-- > 0)
                {
                    //Random between 0 and sum
                    var pointer = RandomHelper.CreateRandom(0, totalRoulet);
                    for (int i = 0; i < SelectionBoxs.Count; i++)
                    {
                        if (pointer <= SelectionBoxs[i].Fitness)
                        {
                            selection.Add(SelectionBoxs[i]);
                            break;
                        }
                        pointer -= SelectionBoxs[i].Fitness;
                    }
                }
            });
            return selection;
        }
    }
}
