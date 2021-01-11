namespace knapsackEvolutionALgorithm.Service.Entities.Common
{
    public abstract class BaseChromosome<TGenerate, TFitness>
    {
        #region Properties
        public TFitness Fitness { get; set; }
        public TGenerate[] Generate { get; set; }
        #endregion
    }
}
