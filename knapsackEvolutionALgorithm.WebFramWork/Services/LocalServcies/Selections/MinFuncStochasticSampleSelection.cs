
using knapsackEvolutionALgorithm.Service.Common.Utilities;
using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections
{
    public class MinFuncStochasticSampleSelection
        : ISelectionMethod<IList<MinFuncIndividual>, IList<MinFuncIndividual>>
    {
        public Task<IList<MinFuncIndividual>> HandleSelection(IList<MinFuncIndividual> selectionBoxs, int amountOfSelection, Selection selection)
        {
            if (selection == Selection.SUS)
            {
                IList<MinFuncIndividual> selectiveIndividulas = new List<MinFuncIndividual>();
                selectionBoxs = selectionBoxs.OrderByDescending(S => S.Fitness).ToList();
                var totalfitness = ComputeCumulativeSum(selectionBoxs);

                var pointer = (RandomHelper.CreateRandom(0, totalfitness / amountOfSelection) );

                double ptr = 0;

                foreach (var individual in selectionBoxs)
                {
                    ptr += individual.Fitness;
                    while ((ptr - individual.Fitness <= pointer && pointer <= ptr) || totalfitness == 0)
                    {
                        selectiveIndividulas.Add(individual);
                        pointer += totalfitness / amountOfSelection;
                        if (selectiveIndividulas.Count() == amountOfSelection)
                            break;
                    }
                    if (selectiveIndividulas.Count() == amountOfSelection)
                        break;
                }
                #region OldCode
                /*
                foreach (var individual in selectionBoxs)
                {
                    ptr += individual.Fitness;
                    if (pointer <= ptr)
                    {
                        selectiveIndividulas.Add(individual);
                        if (selectiveIndividulas.Count() == amountOfSelection) 
                            break;
                        pointer += _totalFitness / amountOfSelection;
                    }
                }*/
                #endregion
                return Task.FromResult(selectiveIndividulas);
            }
            return Task.FromResult(new List<MinFuncIndividual>() as IList<MinFuncIndividual>);

        }

        private double ComputeCumulativeSum(IList<MinFuncIndividual> selectionBoxs)
        {
            var totalfitness = 0.0;
            foreach (var individual in selectionBoxs)
                totalfitness += individual.Fitness;
            return totalfitness;
        }
    }
}
