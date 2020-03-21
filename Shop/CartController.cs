using System;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Command;
using ShoppingCart.Message;
using ShoppingCart.Repository;

namespace ShoppingCart.Shop
{
    public class CartController : Controller
    {
        private readonly IBus _bus;
        private readonly IRepository<Data.ShoppingCart> _repository;

        public CartController(IBus bus, IRepository<Data.ShoppingCart> repository) : base()
        {
            _bus = bus;
            _repository = repository;
        }

        [HttpPost("/api/cart")]
        public IActionResult Create()
        {
            var id = Guid.NewGuid();

            _bus.Dispatch(new CreateCart(id));

            return Created($"/api/cart/{id}", null);
        }

        [HttpGet("/api/cart/{cartId}")]
        public IActionResult Get([FromRoute] Guid cartId)
        {
            return Ok(_repository.LoadById(cartId));
        }

        [HttpPost("/api/cart/{cartId}/item")]
        public IActionResult AddItem([FromRoute] Guid cartId)
        {
            var itemId = Guid.NewGuid();

            _bus.Dispatch(new AddItemToCart(itemId, cartId));

            return Ok(_repository.LoadById(cartId));
        }

        [HttpDelete("/api/cart/{cartId}/item/{itemId}")]
        public IActionResult RemoveItem([FromRoute] Guid cartId, [FromRoute] Guid itemId)
        {
            _bus.Dispatch(new RemoveItemFromCart(itemId, cartId));

            return Ok(_repository.LoadById(cartId));
        }
    }
}
