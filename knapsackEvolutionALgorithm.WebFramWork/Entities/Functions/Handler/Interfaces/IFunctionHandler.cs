using knapsackEvolutionALgorithm.Service.Entities.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Entities.Functions.Handler.Interfaces
{
    public interface IFunctionHandler
    {
        Task Handle(IList<IFunction> functions, FunctionSelected selected);
    }
}
