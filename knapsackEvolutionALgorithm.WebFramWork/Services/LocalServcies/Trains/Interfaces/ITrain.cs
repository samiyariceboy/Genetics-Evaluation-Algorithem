using knapsackEvolutionALgorithm.Service.Entities;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies
{
    public interface ITrain<in TModelInput, TExcetedFitness>
        where TModelInput : BaseGettingStarted
    {
        public TExcetedFitness ExcetedFitness { get; set; }
        Task DoTrain(TModelInput gettingStarted);
    }
}
