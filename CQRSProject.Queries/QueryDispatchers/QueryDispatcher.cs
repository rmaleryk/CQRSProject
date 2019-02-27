using System;
using System.Threading.Tasks;
using CQRSProject.Queries.Extensibility;

namespace CQRSProject.Queries.QueryDispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<TResult> ExecuteAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var handler = (IQueryHandler<TQuery, TResult>)serviceProvider.GetService(typeof(IQueryHandler<TQuery, TResult>));

            if (handler == null)
            {
                throw new ArgumentException(nameof(TQuery));
            }

            return await handler.ExecuteAsync(query);
        }
    }
}