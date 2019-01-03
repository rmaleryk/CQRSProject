using System;

namespace CQRSProject.Domain.Entities
{
    public class ShopItem
    {
        public Guid Id { get; }

        public string Name { get; }

        public ShopItem(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}