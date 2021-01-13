using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Trains.Handlers.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Trains.Handlers
{
    public class TrainerHandler : ITrainerHandler<MinFunGettingStarted>
    {
        private IList<object> _trainerRequestList = new List<object>();

        public TrainerHandler(IList<object> trainerRequestList)
        {
            _trainerRequestList = trainerRequestList;
        }
        public async Task<bool> ProcessDoTrain(MinFunGettingStarted gettingStarted)
        {
            
            foreach (ITrain<MinFunGettingStarted, int> trainer in _trainerRequestList)
            {
                if(await trainer.DoTrain(gettingStarted) is true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
