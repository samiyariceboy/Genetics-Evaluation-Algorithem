using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Trains;
using System;

namespace knapsackEvolutionALgorithm.Service.Entities.Common
{
    public class CounterChangeEventArgument : EventArgs
    {
        public CounterChangeEventArgument(int parentIntex)
        {
            ParentIntex = parentIntex;
        }

        public int ParentIntex { get; }
    }

    public class MaximumChangeEventArgument : EventArgs
    {
        public MaximumChangeEventArgument(MinFuncIndividual maximumChild, int parent, int Try, MutationOrRecombination mutationOrRecombination)
        {
            MaximumChild = maximumChild;
            Parent = parent;
            this.Try = Try;
            MutationOrRecombination = mutationOrRecombination;
        }

        public MinFuncIndividual MaximumChild { get; }
        public int Parent { get; }
        public int Try { get; }
        public MutationOrRecombination MutationOrRecombination { get; }
    }
}
