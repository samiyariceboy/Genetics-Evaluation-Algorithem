
using knapsackEvolutionALgorithm.Service.Common.Utilities;
using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Mutations;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Recombinations.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Recombinations
{
    public class CrossOver : IRecombinationMethod<Individual, Individual>
    {
        private readonly IList<Item> _items;
        private readonly int _knapsackCapacity;

        private readonly SimpleMutation _simpleMutation;

        public CrossOver(IList<Item> items, int knapsackCapacity)
        {
            _items = items;
            _knapsackCapacity = knapsackCapacity;

            _simpleMutation = new SimpleMutation(items, knapsackCapacity);
        }

        public async Task<(Individual first, Individual second)> HandleRecombination(Individual first, Individual second, Recombination recombination)
        {

            var point1 = RandomHelper.CreateRandom(1, first.Generate.Count());
            var point2 = RandomHelper.CreateRandom(point1, first.Generate.Count());
            bool[] child1Generate = new bool[first.Generate.Count()];
            bool[] child2Generate = new bool[first.Generate.Count()];

            await Task.Run(() =>
            {
                for (int i = 0; i < first.Generate.Count(); i++)
                {
                    if (point1.Equals(point2))
                    {
                        child1Generate[i] = (i < point1) ? first.Generate[i] : second.Generate[i];
                        child2Generate[i] = (i < point1) ? second.Generate[i] : first.Generate[i];
                    }
                    else
                    {
                        child1Generate[i] = (i < point1) ? first.Generate[i]
                                                         : ((i < point2) ? second.Generate[i] : first.Generate[i]);
                        child2Generate[i] = (i < point1) ? second.Generate[i]
                                                         : ((i < point2) ? first.Generate[i] : second.Generate[i]);
                    }
                }
            });
            var child1 = new Individual(child1Generate, _items, _knapsackCapacity);
            var child2 = new Individual(child2Generate, _items, _knapsackCapacity);

            //noise for mutation
            if (RandomHelper.CreateRandom(0, 100) < 35)
                child1 = await _simpleMutation.HandleMutation(child1, Mutation.None);
            if (RandomHelper.CreateRandom(0, 100) < 35)
                child2 = await _simpleMutation.HandleMutation(child2, Mutation.None);
            return (child1, child2);

        }
    }
}
