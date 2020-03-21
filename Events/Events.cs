using System;

namespace ShoppingCart.Events
{
    public interface IEvent
    {
    }

    public abstract class Event : IEvent
    {
        public int Version { get; set; }
    }

    public class CartCreated : Event
    {
        public Guid Id { get; }

        public CartCreated(Guid id)
        {
            Id = id;
        }
    }

    public class ItemAddedToCart : Event
    {
        public Guid Id { get; }
        public Guid CartId { get; }
        public string Name { get; }

        public ItemAddedToCart(Guid id, Guid cartId, string name)
        {
            Id = id;
            CartId = cartId;
            Name = name;
        }
    }

    public class ItemRemovedFromCart : Event
    {
        public Guid Id { get; }
        public Guid CartId { get; }

        public ItemRemovedFromCart(Guid id, Guid cartId)
        {
            Id = id;
            CartId = cartId;
        }
    }
}
