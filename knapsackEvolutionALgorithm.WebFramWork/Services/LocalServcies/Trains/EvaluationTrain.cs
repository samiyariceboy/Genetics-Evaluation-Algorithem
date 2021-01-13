using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Recombinations;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies
{
    public delegate void ChangeNotification(Individual maximumChild, int parent, int Try);
    public delegate void Notification(int changed);
    public class EvaluationTrain : ITrain<GettingStarted, int>
    {
        public event ChangeNotification MaximumChildChanged;
        public event Notification TryChanged;
        public event Notification ParentChanged;

        public int ExcetedFitness { get; set; }

        private readonly RandomSelection _randomSelection;
        private readonly RouletteWeel2Selection _rouletteWeelSelection;

        private readonly CrossOver _crossOver;

        public EvaluationTrain(GettingStarted gettingStarted)
        {
            _randomSelection = new RandomSelection(gettingStarted.EarlyPopulation);
            _rouletteWeelSelection = new RouletteWeel2Selection();
            _crossOver = new CrossOver(gettingStarted.Items, gettingStarted.KnapsakCapacity);
        }


        /// <summary>
        /// this method Start Training
        /// </summary>
        /// <returns></returns>

        public async Task<bool> DoTrain(GettingStarted gettingStarted)
        {
            var firstPopulation = await _randomSelection.HandleSelection(gettingStarted.Items, gettingStarted.KnapsakCapacity, Selection.Random);
            var maximumChild = new Individual(gettingStarted.Items);
            await Task.Run(() => 
            {
                for (int i = 0; i < gettingStarted.NumberOfGenerationRepetitions; i++)
                {
                    TryChanged.Invoke(i);
                    var parent =  _rouletteWeelSelection.HandleSelection(firstPopulation, gettingStarted.NumberOfParents, Selection.RouletteWheel).Result;
                    //فاصله گرفتن از  
                    firstPopulation = _rouletteWeelSelection.HandleSelection(parent, gettingStarted.NumberOfParents, Selection.RouletteWheel).Result;

                    for (int j = 0; j < gettingStarted.NumberOfParents ; j++)
                    {
                        ParentChanged.Invoke(j);
                        if (firstPopulation[j].Fitness > maximumChild.Fitness)
                        {
                            maximumChild = firstPopulation[j];

                            //Send Notification
                            MaximumChildChanged.Invoke(maximumChild, j, i);
                        }
                        if (firstPopulation[j + 1].Fitness > maximumChild.Fitness)
                        {
                            maximumChild = firstPopulation[j + 1];

                            //Send Notification
                            MaximumChildChanged.Invoke(maximumChild, j, i);
                        }

                        //Recombination between two chromosomes together
                        var childs = _crossOver.HandleRecombination(firstPopulation[j], firstPopulation[j + 1], Recombination.None).Result;

                        /// میو + لاندا
                        firstPopulation.Add(childs.first);
                        if (childs.first.Fitness > maximumChild.Fitness)
                        {
                            maximumChild = childs.first;

                            //Send Notification
                            MaximumChildChanged.Invoke(maximumChild, j, i);
                        }

                        firstPopulation.Add(childs.second);
                        if (childs.second.Fitness > maximumChild.Fitness)
                        {
                            maximumChild = childs.second;

                            //Send Notification
                            MaximumChildChanged.Invoke(maximumChild, j, i);
                        }
                    }
                }
            });
            ExcetedFitness = maximumChild.Fitness;
            return true;
        }
    }
}
