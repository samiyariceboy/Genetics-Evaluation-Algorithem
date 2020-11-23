using knapsackEvolutionALgorithm.Service.Common.Utilities;
using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections
{
    public class RouletteWeel2Selection : ISelectionMethod<IList<Individual>, IList<Individual>>
    {
        public async Task<IList<Individual>> HandleSelection(IList<Individual> SelectionBoxs, int capacity)
        {
            var totalRoulet = 0;
            var selection = new List<Individual>();
            //Sum of all Fitness
            await Task.Run(() =>
            {
                for (int i = 0; i < SelectionBoxs.Count; i++)
                    totalRoulet += SelectionBoxs[i].Fitness;
            });

            await Task.Run(() => 
            {
                while (capacity-- > 0)
                {   
                    var pointe = RandomHelper.CreateRandom(0, totalRoulet);
                    for (int i = 0; i < SelectionBoxs.Count(); i++)
                    {
                        if (pointe <= SelectionBoxs[i].Fitness)
                        {
                            selection.Add(SelectionBoxs[i]);
                            break;
                        }
                        pointe -= SelectionBoxs[i].Fitness;
                    }
                }
            });

            return selection;
        }
    }
}
