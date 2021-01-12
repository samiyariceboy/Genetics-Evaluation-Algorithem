using knapsackEvolutionALgorithm.Service.Common.Utilities;
using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Interfaces;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IList<MinFuncIndividual>> HandleSelection(IList<MinFuncIndividual> selectionBoxs, int amountOfRandomNumber)
        {
            //amountOfRandomNumber: تعداد انتخاب از بین جممعیت
            var kInNetIndividulas = new List<MinFuncIndividual>();
            IList<MinFuncIndividual> selectiveIndividulas = new List<MinFuncIndividual>();
            await Task.Run(() => 
            {
                //Choose randon from selectionBox
                for (int i = 0; i < _kInNetIndividulas; i++)
                    kInNetIndividulas.Add(
                            selectionBoxs[RandomHelper.CreateRandom(0, selectionBoxs.Count())]
                        );
            });
            selectiveIndividulas = await _rouletteWeelSelection.HandleSelection(kInNetIndividulas, amountOfRandomNumber);
            return selectiveIndividulas;
        }
    }
}
