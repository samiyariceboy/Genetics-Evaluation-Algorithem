namespace knapsackEvolutionALgorithm.Service.Entities.Common
{
    public interface IFunction
    {
        double Implement(int nCount);
        double ComputeFitness(int nCount);
    }

}
