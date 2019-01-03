using CQRSProject.Domain.Entities;
using CQRSProject.Domain.Extensibility.Repositories;

namespace CQRSProject.DataAccess.Write.Repositories
{
    public class ShopItemWriteRepository : IWriteRepository<ShopItem>
    {
        public void Save(ShopItem entity)
        {
            throw new System.NotImplementedException();
        }
    }
}