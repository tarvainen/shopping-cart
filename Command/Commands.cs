using System;
namespace ShoppingCart.Command
{
    public interface ICommand
    {
    }

    public abstract class Command : ICommand
    {
    }

    public class CreateCart : Command
    {
        public Guid CartId { get; }

        public CreateCart(Guid cartId)
        {
            CartId = cartId;
        }
    }

    public class AddItemToCart : Command
    {
        public Guid ItemId { get; }
        public Guid CartId { get; }

        public AddItemToCart(Guid itemId, Guid cartId)
        {
            ItemId = itemId;
            CartId = cartId;
        }
    }

    public class RemoveItemFromCart : Command
    {
        public Guid ItemId { get; }
        public Guid CartId { get; }

        public RemoveItemFromCart(Guid itemId, Guid cartId)
        {
            ItemId = itemId;
            CartId = cartId;
        }
    }
}
