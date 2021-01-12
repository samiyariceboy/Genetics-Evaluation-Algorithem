using knapsackEvolutionALgorithm.Service.Common.Utilities;
using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections
{
    public class MinFuncSelfAdaptionRandomSelection
        : ISelectionMethod<IList<MinFuncIndividual>, IList<MinFuncIndividual>>
    {
        private readonly int _numberOfEarlyPopulation;

        public MinFuncSelfAdaptionRandomSelection(int numberOfEarlyPopulation)
        {
            _numberOfEarlyPopulation = numberOfEarlyPopulation;
        }
        public async Task<IList<MinFuncIndividual>> HandleSelection(IList<MinFuncIndividual> SelectionBoxs, int chromosomeLength)
        {
            var firstPopulation = new List<MinFuncIndividual>();
            await Task.Run(() =>
            {
                for (int i = 0; i < _numberOfEarlyPopulation; i++)
                {
                    firstPopulation.Add(new MinFuncIndividual(
                            new double[chromosomeLength].GenerateRandom(),
                            0,
                            RandomHelper.CreateRandom(1000, 9999)/1000
                        ));
                }
            });
            return firstPopulation;
        }


    }
}
