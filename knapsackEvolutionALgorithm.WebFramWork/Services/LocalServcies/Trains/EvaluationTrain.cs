using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Recombinations;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies
{
    public delegate void Notification(Individual maximumChild, int Try);
    public class EvaluationTrain : ITrain
    {
        public GettingStarted GettingStarted { get; init; }

        public event Notification MaximumChildChanged;

        public int ExcetedFitness { get; set; }

        private readonly RandomSelection _randomSelection;
        private readonly RouletteWeel2Selection _rouletteWeelSelection;

        private readonly CrossOver _crossOver;

        public EvaluationTrain(GettingStarted gettingStarted)
        {
             GettingStarted = gettingStarted;

            _randomSelection = new RandomSelection(gettingStarted.EarlyPopulation);
            _rouletteWeelSelection = new RouletteWeel2Selection();
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
                    //فاصله گرفتن از  
                    firstPopulation = _rouletteWeelSelection.HandleSelection(parent, GettingStarted.NumberOfParents).Result;

                    for (int j = 0; j < GettingStarted.NumberOfParents ; j++)
                    {
                        if (firstPopulation[j].Fitness > maximumChild.Fitness)
                        {
                            maximumChild = firstPopulation[j];
                            MaximumChildChanged.Invoke(maximumChild, i);
                        }
                        if (firstPopulation[j + 1].Fitness > maximumChild.Fitness)
                        {
                            maximumChild = firstPopulation[j + 1];
                            MaximumChildChanged.Invoke(maximumChild, i);
                        }

                        //Recombination 
                        var childs = _crossOver.HandleRecombination(firstPopulation[j], firstPopulation[j + 1]).Result;

                        /// میو + لاندا
                        firstPopulation.Add(childs.first);
                        if (childs.first.Fitness > maximumChild.Fitness)
                        {
                            maximumChild = childs.first;
                            MaximumChildChanged.Invoke(maximumChild, i);
                        }

                        firstPopulation.Add(childs.second);
                        if (childs.second.Fitness > maximumChild.Fitness)
                        {
                            maximumChild = childs.second;
                            MaximumChildChanged.Invoke(maximumChild, i);
                        }
                    }
                }
            });
            ExcetedFitness = maximumChild.Fitness;
        }
    }
}
