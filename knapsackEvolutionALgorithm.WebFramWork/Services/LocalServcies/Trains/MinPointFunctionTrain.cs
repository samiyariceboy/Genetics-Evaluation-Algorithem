using knapsackEvolutionALgorithm.Service.Common.Utilities;
using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Entities.Common;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Interfaces;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Mutations;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Mutations.Interfaces;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Recombinations;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Recombinations.Interfaces;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Troschuetz.Random.Distributions.Continuous;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Trains
{
    public class MinPointFunctionTrain : ITrain<MinFunGettingStarted, int>
    {
        #region Properties and fields

        private readonly IFunction _function;
        private readonly MinFuncRandomSelection _normalRandomSelection;
        private readonly IEsMutationMethod<MinFuncIndividual, MinFuncIndividual> _onePerFiveMutation;


        private readonly ISelectionMethod<IList<MinFuncIndividual>, IList<MinFuncIndividual>> _rouletteWheelSelection;
        private readonly ISelectionMethod<IList<MinFuncIndividual>, IList<MinFuncIndividual>> _tournamentSelection;

        IRecombinationMethod<MinFuncIndividual, MinFuncIndividual> _simpleRecombination;
        #endregion



        public int ExcetedFitness { get; set; }

        public MinPointFunctionTrain(MinFunGettingStarted gettingStarted, IFunction function)
        {
            _function = function;
            _normalRandomSelection = new MinFuncRandomSelection(gettingStarted.EarlyPopulation);
            _tournamentSelection = new MinFuncTournamentSelection(gettingStarted.KIndividualTornomantInit);
            _rouletteWheelSelection = new MinFuncRouletteWeelSelection();


            _simpleRecombination = new MinFuncSimpleRecombination(gettingStarted.ChoromosemeLenght, 0.5);
            _onePerFiveMutation = new MinFuncOnePerFiveMutation(gettingStarted.ChoromosemeLenght, gettingStarted.Sigma);
        }

        public async Task DoTrain(MinFunGettingStarted gettingStarted)
        {
            var firstPopulation = await _normalRandomSelection.HandleSelection(null, gettingStarted.ChoromosemeLenght);
            var maximumChild = new MinFuncIndividual(new double[gettingStarted.ChoromosemeLenght]);

            await Task.Run(() =>
            {
                for (int i = 0; i < gettingStarted.NumberOfGenerationRepetitions; i++)
                {
                    var parent = _rouletteWheelSelection.HandleSelection(firstPopulation, gettingStarted.NumberOfParents).Result;
                    for (int j = 0; j < gettingStarted.NumberOfParents; j++)
                    {
                        var random = RandomHelper.CreateRandom(0, 10);  
                        if (random == 5)
                        {
                            //create childs by recombination
                            var childs = _simpleRecombination.HandleRecombination(parent[j], parent[j + 1]).Result;

                            // Compute childs fitness to function
                            childs.first = _function.HandleFitness(childs.first, gettingStarted.ChoromosemeLenght);
                            childs.second = _function.HandleFitness(childs.first, gettingStarted.ChoromosemeLenght);

                            // میو + لاندا
                            firstPopulation.Add(childs.first);
                            firstPopulation.Add(childs.second);
                        }
                        else
                        {
                            //create childs by mutation
                            var mutationChild = _onePerFiveMutation.HandleMutation(parent[j]).Result;

                            //update child fitness => by function
                            var childUpdateFitness = _function.HandleFitness(mutationChild, gettingStarted.ChoromosemeLenght);
                            
                            //update case positive or not
                            _onePerFiveMutation.UpdateCase(mutationChild, childUpdateFitness);

                            // میو + لاندا
                            firstPopulation.Add(childUpdateFitness);
                        }
                    }

                    // update sigma
                    _onePerFiveMutation.UpdateStatus();
                }
            });
        }
    }
}
