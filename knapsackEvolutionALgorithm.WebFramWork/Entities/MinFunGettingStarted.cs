using System.Collections.Generic;

namespace knapsackEvolutionALgorithm.Service.Entities
{
    public class MinFunGettingStarted : BaseGettingStarted
    {
        public MinFunGettingStarted
            (
                int earlyPopulation,
                int numberOfParents,
                int numberOfGenerationRepetitions,

                FunctionSelected functionSelected,
                IList<Selection> selectionList,
                IList<Strategy> strategies
            ) 
            : base(earlyPopulation, numberOfParents, numberOfGenerationRepetitions)
        {
            FunctionSelected = functionSelected;
            SelectionList = selectionList;
            Strategies = strategies;
        }

        public FunctionSelected FunctionSelected { get; }
        public IList<Selection> SelectionList { get; }
        public IList<Strategy> Strategies { get; }
    }

    #region Enums
    public enum Selection
    {
        RouletteWheel,
        SUS,
        Tournament
    }

    public enum Strategy
    {
        OnePerFive,
        SelfAdaptetion
    }

    public enum FunctionSelected
    {
        Function1,
        Function2,
        Function3,
        None
    }
    #endregion
}
