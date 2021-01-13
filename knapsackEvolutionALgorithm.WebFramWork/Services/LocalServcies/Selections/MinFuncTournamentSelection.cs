using knapsackEvolutionALgorithm.Service.Common.Utilities;
using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections
{
    public class MinFuncTournamentSelection
        : ISelectionMethod<IList<MinFuncIndividual>, IList<MinFuncIndividual>>
    {
        private readonly int _kInNetIndividulas;
        private readonly ISelectionMethod<IList<MinFuncIndividual>, IList<MinFuncIndividual>> _rouletteWeelSelection;

        #region Properties
        public MinFuncTournamentSelection(int kInNetIndividulas)
        {
            _kInNetIndividulas = kInNetIndividulas;
            _rouletteWeelSelection = new MinFuncRouletteWeelSelection();
        }
        #endregion

        public Task<IList<MinFuncIndividual>> HandleSelection(IList<MinFuncIndividual> selectionBoxs, int amountOfRandomNumber, Selection selection)
        {
            if (selection == Selection.Tournament)
            {
                IList<MinFuncIndividual> selectiveIndividulas = new List<MinFuncIndividual>();
                IList<MinFuncIndividual> tour = new List<MinFuncIndividual>();
                for (int i = 0; i < amountOfRandomNumber; i++)
                {
                    for (int j = 0; j < _kInNetIndividulas; j++)
                    {
                        var poiter = RandomHelper.CreateRandom(0, (selectionBoxs.Count - 1));
                        tour.Add(selectionBoxs[poiter]);
                    }
                    tour = tour.OrderByDescending(f => f.Fitness).ToList();
                    selectiveIndividulas.Add(tour[0]);
                    tour.Clear();
                }
                return Task.FromResult(selectiveIndividulas);
            }
            return Task.FromResult(new List<MinFuncIndividual>() as IList<MinFuncIndividual>);
        }
    }
}
