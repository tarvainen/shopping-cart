using System;
using System.Linq;
using ShoppingCart.Data;
using ShoppingCart.Events;
using Xunit;

namespace ShoppingCart.Test
{
    public class ShoppingCartTest
    {
        [Fact]
        public void ShoppingCart_CreateCartWillDispatchCartCreated()
        {
            var cart = new Data.ShoppingCart(Guid.NewGuid());

            Assert.Single(cart.GetEvents());
            Assert.IsType<CartCreated>(cart.GetEvents().First());
        }

        [Fact]
        public void ShoppingCart_AddItemWillDispatchItemAdded()
        {
            var cart = new Data.ShoppingCart(Guid.NewGuid());

            cart.ClearEvents();

            cart.AddItem(Guid.NewGuid(), "My cart item");

            Assert.Single(cart.GetEvents());
            Assert.IsType<ItemAddedToCart>(cart.GetEvents().First());
        }

        [Fact]
        public void ShoppingCart_RemoveItemThrowsExceptions()
        {
            var cart = new Data.ShoppingCart(Guid.NewGuid());

            cart.ClearEvents();

            Assert.Throws<ItemNotFoundException>(() => cart.RemoveItem(Guid.NewGuid()));
        }

        [Fact]
        public void ShoppingCart_RemoveItemDispatchItemRemoved()
        {
            var cart = new Data.ShoppingCart(Guid.NewGuid());

            var itemId = Guid.NewGuid();

            cart.AddItem(itemId, "foo");

            cart.ClearEvents();

            cart.RemoveItem(itemId);

            Assert.Single(cart.GetEvents());
            Assert.IsType<ItemRemovedFromCart>(cart.GetEvents().First());
        }
    }
}
