using System.Threading.Tasks;

namespace CQRSProject.Commands.Extensibility
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand command);
    }
}