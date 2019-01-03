using CQRSProject.Domain.Entities;
using CQRSProject.Domain.Extensibility.Repositories;

namespace CQRSProject.DataAccess.Read.Repositories
{
    public class ShopItemReadRepository : IReadRepository<ShopItem>
    {
        public ShopItem[] GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}