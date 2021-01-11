using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections
{
    public class MinFuncStochasticSampleSelection
        : ISelectionMethod<IList<MinFuncIndividula>, IList<MinFuncIndividula>>
    {
        #region Properties
        #endregion
        public MinFuncStochasticSampleSelection
            ()
        {
        }
        public async Task<IList<MinFuncIndividula>> HandleSelection(IList<MinFuncIndividula> SelectionBoxs, int capacity)
        {
            var susSelection = new MinFuncIndividula(new int[SelectionBoxs.Count()], 0);
            SelectionBoxs.OrderBy(S => S.Fitness);
            var totalFitness = SelectionBoxs.Sum(S => S.Fitness);

            await Task.Run(() =>
            {
                for (int i = 0; i < SelectionBoxs.Count; i++)
                {
                    //susSelection.Fitness += 
                }
            });

            return null;
        }
    }
}
