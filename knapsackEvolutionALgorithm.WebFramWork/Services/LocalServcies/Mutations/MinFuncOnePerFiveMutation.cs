using knapsackEvolutionALgorithm.Service.Common.Utilities;
using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Mutations.Interfaces;
using System.Threading.Tasks;
using Troschuetz.Random.Distributions.Continuous;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Mutations
{
    public class MinFuncOnePerFiveMutation : IEsMutationMethod<MinFuncIndividual, MinFuncIndividual>
    {
        private readonly int _chromosomeLength;
        private double _sigma;

        private double _casePositive;
        private double _caseNegative;

        public MinFuncOnePerFiveMutation(int chromosomeLength, double sigma)
        {
            _chromosomeLength = chromosomeLength;
            _sigma = sigma;
        }
        public async Task<MinFuncIndividual> HandleMutation(MinFuncIndividual individual)
        {
            var child = new MinFuncIndividual(new double[_chromosomeLength]);
            await Task.Run(() => 
            {
                for (int i = 0; i < _chromosomeLength; i++)
                    child.Generate[i] = NormalDistribute.DoWork(0, _sigma) + individual.Generate[i];
            });
            
            return child;
        }

        public Task UpdateCase(MinFuncIndividual oldSource, MinFuncIndividual newSource)
        {
            if (newSource.Fitness > oldSource.Fitness)
                _casePositive++;
            else
                _caseNegative++;
            return Task.CompletedTask;
        }



        //update sigma
        public Task UpdateStatus()
        {
            if (_casePositive / (_casePositive + _caseNegative) > 1 / 5)
                _sigma /= 0.9;
            else if (_casePositive / (_casePositive + _caseNegative) < 1 / 5)
                _sigma *= 0.9;
            return Task.CompletedTask;
        }
    }
}
