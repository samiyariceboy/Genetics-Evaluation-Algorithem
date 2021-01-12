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
                int choromosemeLenght,
                double sigma,
                int kIndividualTornomantInit,

                FunctionSelected functionSelected,
                IList<Selection> selectionList,
                IList<Strategy> strategies
            ) 
            : base(earlyPopulation, numberOfParents, numberOfGenerationRepetitions)
        {
            ChoromosemeLenght = choromosemeLenght;
            Sigma = sigma;
            KIndividualTornomantInit = kIndividualTornomantInit;
            FunctionSelected = functionSelected;
            SelectionList = selectionList;
            Strategies = strategies;
        }

        public int ChoromosemeLenght { get; }
        public double Sigma { get; }
        public int KIndividualTornomantInit { get; }
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
