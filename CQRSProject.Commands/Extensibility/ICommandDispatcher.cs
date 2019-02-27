using System.Threading.Tasks;

namespace CQRSProject.Commands.Extensibility
{
    public interface ICommandDispatcher
    {
        Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}