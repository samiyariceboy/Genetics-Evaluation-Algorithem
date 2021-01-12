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
        #region Properties
        private IList<double> _cumulativeSumOfFitness;
        private double _totalFitness;
        #endregion
        public MinFuncStochasticSampleSelection()
        {
            //Create Cumulative sum
            _cumulativeSumOfFitness = new List<double>();
        }
        public async Task<IList<MinFuncIndividual>> HandleSelection(IList<MinFuncIndividual> selectionBoxs, int capacity)
        {
            var selectiveIndividulas = new List<MinFuncIndividual>();
            selectionBoxs.OrderByDescending(S => S.Fitness);

            //Explane: Cumulative sum and return in fields
            await ComputeCumulativeSum(selectionBoxs);

            // Select the best individual that sorted
            selectiveIndividulas.Add(selectionBoxs[0]);

            await Task.Run(() =>
            {
                var random = RandomHelper.CreateRandom(0, int.Parse(_cumulativeSumOfFitness[0].ToString()));
                var stepLength = _totalFitness / capacity;
                for (int i = 0; i < capacity; i++)
                {
                    for (int j = 0; j < _cumulativeSumOfFitness.Count(); j++)
                    {
                        if (_cumulativeSumOfFitness[j] <
                                        ((i * stepLength) + random) &&
                            _cumulativeSumOfFitness[j + 1] > ((i * stepLength) + random))
                            selectiveIndividulas.Add(selectionBoxs[j]);
                    }
                }
            });
            return selectiveIndividulas;
        }

        private Task ComputeCumulativeSum(IList<MinFuncIndividual> selectionBoxs)
        {
            for (int i = 0; i < selectionBoxs.Count; i++)
            {
                _totalFitness += selectionBoxs[i].Fitness;
                _cumulativeSumOfFitness.Add(_totalFitness);
            }
            return Task.CompletedTask;
        }
    }
}
