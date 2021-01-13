using knapsackEvolutionALgorithm.Service.Entities;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Trains.Handlers.Interfaces
{
    public interface ITrainerHandler<in TGettingStarted>
        where TGettingStarted : BaseGettingStarted
    {
        Task<bool> ProcessDoTrain(TGettingStarted gettingStarted);
    }
}
