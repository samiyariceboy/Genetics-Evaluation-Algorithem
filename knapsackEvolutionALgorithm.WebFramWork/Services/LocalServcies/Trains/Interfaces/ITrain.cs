using knapsackEvolutionALgorithm.Service.Entities;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies
{
    public interface ITrain
    {
        public GettingStarted GettingStarted { get; init; }
        Task DoTrain();
    }
}
