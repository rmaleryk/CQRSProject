using System.Collections.Generic;
using System.Linq;
using CQRSProject.Domain.Entities;
using CQRSProject.Domain.Extensibility.Repositories;
using CQRSProject.Queries.Extensibility;
using CQRSProject.Queries.Queries;

namespace CQRSProject.Queries.QueryHandlers
{
    public class ShopItemQueryHandler : IQueryHandler<FindShopItemsByName, IEnumerable<ShopItem>>
    {
        private readonly IReadRepository<ShopItem> repository;

        public ShopItemQueryHandler(IReadRepository<ShopItem> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<ShopItem> Execute(FindShopItemsByName query)
        {
            var users = repository.GetAll();
            return users.Where(user => user.Name.Contains(query.NameKey)).ToArray();
        }
    }
}