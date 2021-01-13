using knapsackEvolutionALgorithm.Service.Common.Utilities;
using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Entities.Functions.Handler;
using knapsackEvolutionALgorithm.Service.Entities.Functions.Handler.Interfaces;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Mutations.Handlers;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Mutations.Handlers.Interfaces;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Recombinations.Handler;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Recombinations.Handler.Interfaces;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections.Handlers;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections.Handlers.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Trains
{
    public delegate void ChangeNotification(MinFuncIndividual minFuncIndividual, MutationOrRecombination mutationOrRecombination, int parentIndex, int tryIndex);
    public delegate void Notification(int idenx);

    public class MinPointFunctionTrain : ITrain<MinFunGettingStarted, MinFuncIndividual>
    {
        #region Handlers
        private readonly ISelectionHandler<IList<MinFuncIndividual>, IList<MinFuncIndividual>> _selectionHandler;
        private readonly IList<object> _selectioList;
        //---------------------------------------------------------
        private readonly IRecombinationHandler<MinFuncIndividual, MinFuncIndividual> _recombinationHandler;
        private readonly IList<object> _recombinationList;
        //---------------------------------------------------------
        private readonly IMutationnHandler<MinFuncIndividual, MinFuncIndividual> _mutationnHandler;
        private readonly IList<object> _mutationList;
        //---------------------------------------------------------
        private readonly IFunctionHandler<MinFuncIndividual, MinFuncIndividual> _functionHandler;
        private readonly IList<object> _functionList;

        #endregion
        #region Events
        public event ChangeNotification MaximumChildChanged;
        public event Notification TryChanged;
        public event Notification ParentChanged;
        #endregion

        public MinFuncIndividual ExcetedFitness { get; set; }

        public MinPointFunctionTrain
            (
                IList<object> selectioList,
                IList<object> recombinationList,
                IList<object> mutationList,
                IList<object> functionList
            )
        {
            #region Init
            _selectioList = selectioList;
            _selectionHandler = new SelectionHandle(_selectioList);
            //---------------------------------------------------------
            _recombinationList = recombinationList;
            _recombinationHandler = new RecombinationHandler(recombinationList);
            //---------------------------------------------------------
            _mutationList = mutationList;
            _mutationnHandler = new MutationHandler(mutationList);
            //---------------------------------------------------------
            _functionList = functionList;
            _functionHandler = new FunctionsHnandler(functionList);
            #endregion
        }
        public async Task<bool> DoTrain(MinFunGettingStarted gettingStarted)
        {
            var firstPopulation = await _selectionHandler.ProcessSelection(null, gettingStarted.ChoromosemeLenght, Selection.Random);
            var maximumChild = new MinFuncIndividual(new double[gettingStarted.ChoromosemeLenght]);

            await Task.Run(() =>
            {
                //var threadId = Thread.CurrentThread.ManagedThreadId;
                for (int i = 0; i < gettingStarted.NumberOfGenerationRepetitions; i++)
                {
                    //threadId = Thread.CurrentThread.ManagedThreadId;
                    TryChanged.Invoke(i);
                    var parent = _selectionHandler.ProcessSelection(firstPopulation, gettingStarted.NumberOfParents, gettingStarted.SelectionList).Result;
                    for (int j = 0; j < gettingStarted.NumberOfParents - 1; j++)
                    {
                        ParentChanged.Invoke(i);
                        var random = RandomHelper.CreateRandom(0, 10);
                        if (random == 5)
                        {
                            //create childs by recombination
                            var childs =  _recombinationHandler.ProcessRecombinationHandler(parent[j], parent[j + 1], gettingStarted.Recombinations).Result;

                            // Compute childs fitness to function
                            var child1New = _functionHandler.ProcessHandleFitness(childs.first, gettingStarted.ChoromosemeLenght, gettingStarted.FunctionSelected).Result;
                            var child2New = _functionHandler.ProcessHandleFitness(childs.second, gettingStarted.ChoromosemeLenght, gettingStarted.FunctionSelected).Result;


                            //Choose Max Child//
                            var chooseChild = (child1New.Fitness >= child2New.Fitness) ?
                                child1New : child2New;

                            if (chooseChild.Fitness > maximumChild.Fitness)
                            {
                                maximumChild = chooseChild;
                                //Invoke
                                MaximumChildChanged.Invoke(maximumChild, MutationOrRecombination.Recombination, j, i);
                            }

                            // میو + لاندا
                            firstPopulation.Add(child1New);
                            firstPopulation.Add(child2New);
                        }
                        else
                        {
                            //create childs by mutation
                            var mutationChild = _mutationnHandler.ProcessMutationHandler(parent[j], gettingStarted.mutationList).Result;

                            //update child fitness => by function
                            var childUpdateFitness = _functionHandler.ProcessHandleFitness(mutationChild, gettingStarted.ChoromosemeLenght, gettingStarted.FunctionSelected).Result;

                            //Choose Max Child //

                            if (childUpdateFitness.Fitness > maximumChild.Fitness)
                            {
                                maximumChild = childUpdateFitness;
                                //Invoke
                                //MaximumChildChanged.Invoke(maximumChild, MutationOrRecombination.Mutation, j, i);
                                MaximumChildChanged.Invoke(maximumChild, MutationOrRecombination.Mutation, j, i);
                            }

                            //update case positive or not
                            _mutationnHandler.ProcessUpdateCase(mutationChild, childUpdateFitness, gettingStarted.mutationList);

                            // میو + لاندا
                            firstPopulation.Add(childUpdateFitness);
                        }
                    }
                    // update sigma
                    _mutationnHandler.ProcessUpdateStatus(gettingStarted.mutationList);
                }
                ExcetedFitness = _functionHandler.ProcessHanldeExcutedFitness(maximumChild, gettingStarted.FunctionSelected).Result;
            });
            
            return true;
        }
    }

    #region Enums
    public enum MutationOrRecombination
    {
        Mutation,
        Recombination
    }
    #endregion
}
