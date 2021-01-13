using knapsackEvolutionALgorithm.Service.Common.Utilities;
using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Recombinations.Interfaces;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Recombinations
{
    public class MinFuncSimpleRecombination
        : IRecombinationMethod<MinFuncIndividual, MinFuncIndividual>
    {
        private readonly int _chromosomeLength;
        private readonly double _alfa;

        public MinFuncSimpleRecombination(int chromosomeLength, double alfa)
        {
            _chromosomeLength = chromosomeLength;
            _alfa = alfa;
        }
        public Task<(MinFuncIndividual first, MinFuncIndividual second)> HandleRecombination(MinFuncIndividual parent1, MinFuncIndividual parent2, Recombination recombination)
        {
            if (recombination == Recombination.Simple)
            {
                var random = RandomHelper.CreateRandom(0, _chromosomeLength);
                var child1 = new MinFuncIndividual(new double[_chromosomeLength]);
                var child2 = new MinFuncIndividual(new double[_chromosomeLength]);

                for (int i = random; i < _chromosomeLength; i++)
                {
                    child1.Generate[i] = (parent1.Generate[i] * _alfa) + (parent2.Generate[i] * (1 - _alfa));
                    child2.Generate[i] = (parent1.Generate[i] * _alfa) + (parent2.Generate[i] * (1 - _alfa));
                }
                return Task.FromResult((child1, child2));
            }
            return Task.FromResult((new MinFuncIndividual(null), new MinFuncIndividual(null)));
        }
    }
}
