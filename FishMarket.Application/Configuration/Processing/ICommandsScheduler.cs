using System.Threading.Tasks;
using FishMarket.Application.Configuration.Commands;

namespace FishMarket.Application.Configuration.Processing
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync<T>(ICommand<T> command);
    }
}