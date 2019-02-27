using System.Threading.Tasks;

namespace CQRSProject.Commands.Extensibility
{
    public interface IEventStore
    {
        Task StoreCommandAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}