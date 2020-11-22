using knapsackEvolutionALgorithm.Service.Common.Utilities;
using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections
{
    public class RandomSelection 
        : ISelectionMethod<IList<Item>, IList<Individual>>
    {
        public int NumberOfEarlyPopulation { get; }

        public RandomSelection(int numberOfEarlyPopulation)
        {
            NumberOfEarlyPopulation = numberOfEarlyPopulation;
        }

        public async Task<IList<Individual>> HandleSelection(IList<Item> SelectionBoxs, int capacity)
        {
            var firstPopulation = new List<Individual>();
            var numberOfEarlyPopulation = NumberOfEarlyPopulation;
            await Task.Run(() =>
            {
                while (numberOfEarlyPopulation-- > 0)
                {
                    var generate = new bool[SelectionBoxs.Count()].GenerateRandom();
                    firstPopulation.Add(new Individual(generate, SelectionBoxs, capacity));
                }
            });
            return firstPopulation;
        }
    }
}
