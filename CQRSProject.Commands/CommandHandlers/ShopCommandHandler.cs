using CQRSProject.Commands.Commands;
using CQRSProject.Commands.Extensibility;
using CQRSProject.Domain.Entities;
using CQRSProject.Domain.Extensibility.Repositories;

namespace CQRSProject.Commands.CommandHandlers
{
    public class ShopCommandHandler : ICommandHandler<CreateShopItem>
    {
        private readonly IWriteRepository<ShopItem> repository;

        public ShopCommandHandler(IWriteRepository<ShopItem> repository)
        {
            this.repository = repository;
        }

        public void Execute(CreateShopItem message)
        {
            var item = new ShopItem(message.ItemId, message.Name);
            repository.Save(item);
        }
    }
}