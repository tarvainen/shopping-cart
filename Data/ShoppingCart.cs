using System;
using System.Collections.Generic;
using ShoppingCart.Events;

namespace ShoppingCart.Data
{
    public class Item
    {
        public Guid Id { get; }
        public string Name { get; }

        public Item(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class ShoppingCart : Aggregate
    {
        public List<Item> Items { get; } = new List<Item>();

        public ShoppingCart()
        {
        }

        public ShoppingCart(Guid id)
        {
            ApplyChange(new CartCreated(id));
        }

        public void AddItem(Guid itemId, string name)
        {
            ApplyChange(new ItemAddedToCart(itemId, Id, name));
        }

        public void RemoveItem(Guid itemId)
        {
            ApplyChange(new ItemRemovedFromCart(itemId, Id));
        }

        public void Apply(CartCreated evt)
        {
            Id = evt.Id;
        }

        public void Apply(ItemAddedToCart evt)
        {
            Items.Add(new Item(evt.Id, evt.Name));
        }

        public void Apply(ItemRemovedFromCart evt)
        {
            var removed = Items.RemoveAll(x => x.Id == evt.Id);

            if (removed == 0)
            {
                throw new ItemNotFoundException();
            }
        }
    }

    public class ItemNotFoundException : Exception
    {
    }
}
