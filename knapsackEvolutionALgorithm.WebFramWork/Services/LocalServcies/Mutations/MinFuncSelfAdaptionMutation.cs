using knapsackEvolutionALgorithm.Service.Common.Utilities;
using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Mutations.Interfaces;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Mutations
{
    public class MinFuncSelfAdaptionMutation
        : IEsMutationMethod<MinFuncIndividual, MinFuncIndividual>
    {
        private readonly int _chromosomeLength;
        private double _sigma;

        private double _casePositive;
        private double _caseNegative;

        public MinFuncSelfAdaptionMutation(int chromosomeLength, double sigma)
        {
            _chromosomeLength = chromosomeLength;
            _sigma = sigma;
        }

        public async Task<MinFuncIndividual> HandleMutation(MinFuncIndividual individual)
        {
            var child = new MinFuncIndividual(new double[_chromosomeLength]);
            child.Sigma = NormalDistribute.DoWork(0, individual.Sigma) + individual.Sigma;

            await Task.Run(() =>
            {
                for (int i = 0; i < _chromosomeLength; i++)
                    child.Generate[i] = NormalDistribute.DoWork(0, _sigma) + individual.Generate[i];
            });

            return child;
        }

        public Task UpdateCase(MinFuncIndividual oldSource, MinFuncIndividual newSource)
        {
            return Task.CompletedTask;
        }

        public Task UpdateStatus()
        {
            return Task.CompletedTask;
        }
    }
}
