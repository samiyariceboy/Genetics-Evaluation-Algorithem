using System.Collections.Generic;

namespace knapsackEvolutionALgorithm.Service.Entities
{
    public class GettingStarted : BaseGettingStarted
    {
        public GettingStarted(int knapsakCapacity, int earlyPopulation, int numberOfParents, int numberOfGenerationRepetitions, IList<Item> items)
            : base(earlyPopulation, numberOfParents, numberOfGenerationRepetitions)
        {
            KnapsakCapacity = knapsakCapacity;
            Items = items;
        }

        public int KnapsakCapacity { get; init; }
        public IList<Item> Items { get; init; }
    }
}   
