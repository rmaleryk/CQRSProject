using System.Threading.Tasks;

namespace CQRSProject.Queries.Extensibility
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> ExecuteAsync(TQuery query);
    }
}