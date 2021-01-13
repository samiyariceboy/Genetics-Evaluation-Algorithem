using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Entities.Common
{
    public interface IFunction
    {
        double Implement(MinFuncIndividual individual, int nCount);
        Task<MinFuncIndividual> HandleFitness(MinFuncIndividual individual, int chromosomeLength, FunctionSelected functionSelected);
        Task<MinFuncIndividual> ExcutedFitness(MinFuncIndividual individual, FunctionSelected functionSelected);
    }

}
