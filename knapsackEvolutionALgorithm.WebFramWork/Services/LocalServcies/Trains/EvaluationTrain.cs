using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Recombinations;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies
{
    public class EvaluationTrain : ITrain
    {
        public GettingStarted GettingStarted { get; init; }
        public int ExcetedFitness { get; set; }

        private readonly RandomSelection _randomSelection;
        private readonly RouletteWeelSelection _rouletteWeelSelection;

        private readonly CrossOver _crossOver;

        public EvaluationTrain(GettingStarted gettingStarted)
        {
             GettingStarted = gettingStarted;

            _randomSelection = new RandomSelection(gettingStarted.EarlyPopulation);
            _rouletteWeelSelection = new RouletteWeelSelection();

            _crossOver = new CrossOver(gettingStarted.Items, gettingStarted.KnapsakCapacity);

        }

        /// <summary>
        /// this method Start Training
        /// </summary>
        /// <returns></returns>

        public async Task DoTrain()
        {

            var firstPopulation = await _randomSelection.HandleSelection(GettingStarted.Items, GettingStarted.KnapsakCapacity);
            var maximumChild = new Individual(GettingStarted.Items);
            await Task.Run(() => 
            {
                for (int i = 0; i < GettingStarted.NumberOfGenerationRepetitions; i++)
                {
                    var parent =  _rouletteWeelSelection.HandleSelection(firstPopulation, GettingStarted.NumberOfParents).Result;
                    /// ایجاد یک رولت ویل بر روی جمعیت اولیه
                    firstPopulation = _rouletteWeelSelection.HandleSelection(parent, GettingStarted.NumberOfParents).Result;

                    for (int j = 0; j < GettingStarted.NumberOfParents ; j++)
                    {
                        if (firstPopulation[j].Fitness > maximumChild.Fitness)
                            maximumChild = firstPopulation[j];
                        if (firstPopulation[j + 1].Fitness > maximumChild.Fitness)
                            maximumChild = firstPopulation[j + 1];
                        var childs = _crossOver.HandleRecombination(firstPopulation[j], firstPopulation[j + 1]).Result;

                        firstPopulation.Add(childs.first);
                        if (childs.first.Fitness > maximumChild.Fitness)
                            maximumChild = childs.first;

                        firstPopulation.Add(childs.second);
                        if (childs.second.Fitness > maximumChild.Fitness)
                            maximumChild = childs.second;
                    }
                }
            });
            ExcetedFitness = maximumChild.Fitness;
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
