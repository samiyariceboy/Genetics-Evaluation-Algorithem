using knapsackEvolutionALgorithm.Service.Common.Utilities;
using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections
{
    public class MinFuncRouletteWeelSelection
         : ISelectionMethod<IList<MinFuncIndividual>, IList<MinFuncIndividual>>
    {
        public Task<IList<MinFuncIndividual>> HandleSelection(IList<MinFuncIndividual> selectionBoxs, int numberOfSelection, Selection selection)
        {
            if (selection == Selection.RouletteWheel)
            {
                IList<MinFuncIndividual> selectiveIndividulas = new List<MinFuncIndividual>();
                var camulativ = ComputeCumulativeSum(selectionBoxs);

                for (int i = 0; i < numberOfSelection; i++)
                {
                    var random = RandomHelper.CreateRandom(0, camulativ.cumulativeSumOfFitness[selectionBoxs.Count() - 1]);
                    for (int j = 0; j < camulativ.cumulativeSumOfFitness.Count() - 1; j++)
                    {
                        if ((random >= camulativ.cumulativeSumOfFitness[j] && random <= camulativ.cumulativeSumOfFitness[j + 1]) || camulativ.totalFitness == 0)
                        {
                            selectiveIndividulas.Add(selectionBoxs[j]);
                            break;
                        }
                    }
                }
                return Task.FromResult(selectiveIndividulas);
            }
            return Task.FromResult(new List<MinFuncIndividual>() as IList<MinFuncIndividual>);
        }

        private (double totalFitness, IList<double> cumulativeSumOfFitness) ComputeCumulativeSum(IList<MinFuncIndividual> selectionBoxs)
        {
            IList<double> cumulativeSumOfFitness = new List<double>();
            double totalFitness = 0; 
            for (int i = 0; i < selectionBoxs.Count; i++)
            {
                totalFitness += selectionBoxs[i].Fitness;
                cumulativeSumOfFitness.Add(totalFitness);
            }
            return (totalFitness, cumulativeSumOfFitness);
        }

    }
}
