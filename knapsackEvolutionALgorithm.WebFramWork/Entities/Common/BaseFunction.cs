namespace knapsackEvolutionALgorithm.Service.Entities.Common
{
    public interface IFunction
    {
        double Implement(MinFuncIndividual individual, int nCount);
        MinFuncIndividual HandleFitness(MinFuncIndividual individual, int chromosomeLength);
    }

}
