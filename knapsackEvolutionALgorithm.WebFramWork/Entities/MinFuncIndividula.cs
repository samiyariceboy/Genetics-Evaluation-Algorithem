using knapsackEvolutionALgorithm.Service.Entities.Common;

namespace knapsackEvolutionALgorithm.Service.Entities
{
    public class MinFuncIndividula : BaseChromosome<int, double>
    {
        public MinFuncIndividula(int[] generate, double fitness)
        {
            Generate = generate;
            Fitness = fitness;
        }
    }
}
