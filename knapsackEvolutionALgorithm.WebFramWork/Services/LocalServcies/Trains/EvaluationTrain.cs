using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies
{
    public class EvaluationTrain : ITrain
    {
        public GettingStarted GettingStarted { get; init; }
        private readonly RandomSelection _randomSelection;
        private readonly RouletteWeelSelection _rouletteWeelSelection;

        public EvaluationTrain(GettingStarted gettingStarted)
        {
            GettingStarted = gettingStarted;
            _randomSelection = new RandomSelection(gettingStarted.EarlyPopulation);
            _rouletteWeelSelection = new RouletteWeelSelection();
        }

        /// <summary>
        /// this method Start Training
        /// </summary>
        /// <returns></returns>
        
        public async Task DoTrain()
        {

            var firstPopulation = await _randomSelection.HandleSelection(GettingStarted.Items, GettingStarted.KnapsakCapacity);
            var maximumChild = new Individual(GettingStarted.Items);
            for (int i = 0; i < GettingStarted.NumberOfGenerationRepetitions; i++)
            {
                var parent = await _rouletteWeelSelection.HandleSelection(firstPopulation, GettingStarted.NumberOfParents);

                for (int j = 0; j < GettingStarted.NumberOfParents /2; j++)
                {

                }
            }
        }

        #region OldCode
        /*private async Task<IList<Individual>> RandomSelection(IList<Item> items, int numberOfEarlyPopulation, int knapsakCapacity)
        {
            var firstPopulation = new List<Individual>();
            await Task.Run(() =>
            {
                while (numberOfEarlyPopulation-- > 0)
                {
                    var generate = new bool[items.Count].GenerateRandom();
                    firstPopulation.Add(new Individual(generate, items, knapsakCapacity));
                }
            });
            return firstPopulation;
        }
        private async Task<IList<Individual>> RouletteWeelSelection(IList<Individual> individuals, int count)
        {
            var totalRoulet = 0;
            var selection = new List<Individual>();
            await Task.Run(() => 
            {
                for (int i = 0; i < individuals.Count; i++)
                    totalRoulet += individuals[i].Fitness;
            });
            await Task.Run(() => 
            {
                while (count-- > 0)
                {
                    //Random between 0 and sum
                    var pointer = RandomHelper.CreateRandom(0, totalRoulet);
                    for (int i = 0; i < individuals.Count; i++)
                    {
                        if(pointer <= individuals[i].Fitness)
                        {
                            selection.Add(individuals[i]);
                            break;
                        }
                        pointer -= individuals[i].Fitness;
                    }
                }
            });
            return selection;
        }*/
        #endregion
    }
}
