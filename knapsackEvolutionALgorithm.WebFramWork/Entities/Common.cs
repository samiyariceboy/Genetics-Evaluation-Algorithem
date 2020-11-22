using System.Collections.Generic;

namespace knapsackEvolutionALgorithm.Service.Entities
{
    public record GettingStarted
    {
        public GettingStarted(int knapsakCapacity, int earlyPopulation, int numberOfParents, int numberOfGenerationRepetitions, IList<Item> items)
        {
            KnapsakCapacity = knapsakCapacity;
            EarlyPopulation = earlyPopulation;
            NumberOfParents = numberOfParents;
            NumberOfGenerationRepetitions = numberOfGenerationRepetitions;
            Items = items;
        }

        public int KnapsakCapacity { get; init; }
        public int EarlyPopulation { get; init; }
        public int NumberOfParents { get; init; }
        public int NumberOfGenerationRepetitions { get; init; }
        public IList<Item> Items { get; init; }
    }
}   
