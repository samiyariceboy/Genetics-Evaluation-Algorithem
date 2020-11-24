namespace knapsackEvolutionALgorithm.Service.Entities.Common
{
    public abstract class BaseChromosome
    {
        #region Properties
        public int Fitness { get; init; }
        public bool[] Generate { get; init; }
        #endregion
    }
}
