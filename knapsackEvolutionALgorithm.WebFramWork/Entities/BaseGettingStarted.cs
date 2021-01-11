namespace knapsackEvolutionALgorithm.Service.Entities
{
    public abstract class BaseGettingStarted
    {
        protected BaseGettingStarted(int earlyPopulation, int numberOfParents, int numberOfGenerationRepetitions)
        {
            EarlyPopulation = earlyPopulation;
            NumberOfParents = numberOfParents;
            NumberOfGenerationRepetitions = numberOfGenerationRepetitions;
        }

        public int EarlyPopulation { get; }
        public int NumberOfParents { get; }
        public int NumberOfGenerationRepetitions { get; }
    }
}   
