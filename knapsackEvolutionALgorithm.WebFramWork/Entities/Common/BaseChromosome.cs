namespace knapsackEvolutionALgorithm.Service.Entities.Common
{
    public abstract class BaseChromosome
    {
        #region Properties
        public int Fitness { get; set; }
        public bool[] Generate { get;  set; }
        #endregion
    }
}
