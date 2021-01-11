using knapsackEvolutionALgorithm.Service.Entities.Common;
using knapsackEvolutionALgorithm.Service.Entities.Functions.Handler.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Entities.Functions.Handler
{
    public class FunctionsHnandler : IFunctionHandler
    {
        public Task Handle(IList<IFunction> functions, FunctionSelected selected)
        {
            foreach (IFunction function in functions)
            {
            }
            return null;
        }
    }
}
