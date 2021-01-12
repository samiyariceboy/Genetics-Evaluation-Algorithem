using knapsackEvolutionALgorithm.Service.Common.Utilities;
using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Recombinations.Interfaces;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Recombinations
{
    public class MinFuncSingleRecombination
        : IRecombinationMethod<MinFuncIndividual, MinFuncIndividual>
    {
        private readonly int _chromosomeLength;
        private readonly double _alfa;
        public MinFuncSingleRecombination(int chromosomeLength, double alfa)
        {
            _chromosomeLength = chromosomeLength;
            _alfa = alfa;
        }
        public Task<(MinFuncIndividual first, MinFuncIndividual second)> HandleRecombination(MinFuncIndividual parent1, MinFuncIndividual parent2)
        {
            var random = RandomHelper.CreateRandom(0, _chromosomeLength);
            var child1 = new MinFuncIndividual(new double[_chromosomeLength]);
            var child2 = new MinFuncIndividual(new double[_chromosomeLength]);

            child1.Generate[random] = (parent1.Generate[random] * _alfa) + (parent2.Generate[random] * (1-_alfa));
            child2.Generate[random] = (parent1.Generate[random] * _alfa) + (parent2.Generate[random] * (1-_alfa));

            return Task.FromResult((child1, child2));
        }
    }
}
