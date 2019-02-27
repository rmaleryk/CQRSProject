using System.Threading.Tasks;

namespace CQRSProject.Queries.Extensibility
{
    public interface IQueryDispatcher
    {
        Task<TResult> ExecuteAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}