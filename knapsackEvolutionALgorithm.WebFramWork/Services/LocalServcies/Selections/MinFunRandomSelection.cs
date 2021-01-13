using knapsackEvolutionALgorithm.Service.Common.Utilities;
using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections
{
    public class MinFuncRandomSelection
        : ISelectionMethod<IList<MinFuncIndividual>, IList<MinFuncIndividual>>
    {
        private readonly int _numberOfEarlyPopulation;

        public MinFuncRandomSelection(int numberOfEarlyPopulation)
        {
            _numberOfEarlyPopulation = numberOfEarlyPopulation;
        }
        public Task<IList<MinFuncIndividual>> HandleSelection(IList<MinFuncIndividual> SelectionBoxs, int chromosomeLength, Selection selection)
        {
            if (selection == Selection.Random)
            {
                var firstPopulation = new List<MinFuncIndividual>();
                for (int i = 0; i < _numberOfEarlyPopulation; i++)
                {
                    firstPopulation.Add(new MinFuncIndividual(
                            new double[chromosomeLength].GenerateRandom()
                        ));
                }
                return Task.FromResult(firstPopulation as IList<MinFuncIndividual>);
            }
            return Task.FromResult(new List<MinFuncIndividual>() as IList<MinFuncIndividual>);
        }
    }
}
