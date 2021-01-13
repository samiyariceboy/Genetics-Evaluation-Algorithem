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

                int a,
                int b,
                int c,

                FunctionSelected functionSelected,
                Selection selectionList,
                Recombination recombinations,
                Mutation mutations
            ) 
            : base(earlyPopulation, numberOfParents, numberOfGenerationRepetitions)
        {
            ChoromosemeLenght = choromosemeLenght;
            Sigma = sigma;
            KIndividualTornomantInit = kIndividualTornomantInit;
            A = a;
            B = b;
            C = c;
            FunctionSelected = functionSelected;
            SelectionList = selectionList;
            Recombinations = recombinations;
            mutationList = mutations;
        }

        public int ChoromosemeLenght { get; }
        public double Sigma { get; }
        public int KIndividualTornomantInit { get; }
        public int A { get; }
        public int B { get; }
        public int C { get; }
        public FunctionSelected FunctionSelected { get; }
        public Selection SelectionList { get; }
        public Recombination Recombinations { get; }
        public Mutation mutationList { get; }
    }

    #region Enums
    public enum Selection
    {
        Random,
        SelfAdaptionRandom,
        RouletteWheel,
        SUS,
        Tournament,
        None
    }

    public enum Mutation
    {
        OnePerFive,
        SelfAdaptetion,
        None
    }

    public enum Recombination
    {
        Single,
        Simple,
        Whole,
        None
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
