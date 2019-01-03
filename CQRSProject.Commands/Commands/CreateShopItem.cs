using System;
using CQRSProject.Commands.Extensibility;

namespace CQRSProject.Commands.Commands
{
    public class CreateShopItem : ICommand
    {
        public Guid ItemId { get; }

        public string Name { get; }

        public CreateShopItem(Guid itemId, string name)
        {
            ItemId = itemId;
            Name = name;
        }
    }
}