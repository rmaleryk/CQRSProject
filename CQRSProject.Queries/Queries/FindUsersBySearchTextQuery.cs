using System.Collections.Generic;
using CQRSProject.Domain.Entities;
using CQRSProject.Queries.Extensibility;

namespace CQRSProject.Queries.Queries
{
    public class FindShopItemsByName : IQuery<IEnumerable<ShopItem>>
    {
        public string NameKey { get; }

        public FindShopItemsByName(string nameKey)
        {
            NameKey = nameKey;
        }
    }
}