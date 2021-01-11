using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Entities.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Trains
{
    public class MinPointFunctionTrain : ITrain<MinFunGettingStarted, int>
    {
        private readonly IList<IFunction> _functions;

        public int ExcetedFitness { get; set; }

        public MinPointFunctionTrain(IList<IFunction> functions)
        {
            _functions = functions;
        }

        public async Task DoTrain(MinFunGettingStarted gettingStarted)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < gettingStarted.NumberOfGenerationRepetitions; i++)
                {
                    for (int j = 0; j < gettingStarted.NumberOfParents; j++)
                    { 

                    }
                }
            });
        }
    }
}
