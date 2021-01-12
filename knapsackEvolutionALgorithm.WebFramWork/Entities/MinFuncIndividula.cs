using knapsackEvolutionALgorithm.Service.Entities.Common;

namespace knapsackEvolutionALgorithm.Service.Entities
{
    public class MinFuncIndividual : BaseChromosome<double, double>
    {
        public double Sigma { get; set; }
        public MinFuncIndividual(double[] generate)
        {
            Generate = generate;
            Fitness = 0;
        }
        public MinFuncIndividual(double[] generate, double fitness)
        {
            Generate = generate;
            Fitness = fitness;
        }

        public MinFuncIndividual(double[] generate, double fitness, double sigma)
        {
            Generate = generate;
            Fitness = fitness;
            Sigma = sigma;
        }
    }
}
