using ShoppingCart.Repository;

namespace ShoppingCart.Command
{
    public class CommandHandler : ICommandHandler
    {
        private readonly IRepository<Data.ShoppingCart> _repository;

        public CommandHandler(IRepository<Data.ShoppingCart> repository)
        {
            _repository = repository;
        }

        public CommandHandler()
        {
        }

        public void Handle(CreateCart command)
        {
            var cart = new Data.ShoppingCart(command.CartId);
            _repository.Save(cart);
        }

        public void Handle(AddItemToCart command)
        {
            var cart = _repository.LoadById(command.CartId);

            cart.AddItem(command.ItemId, "foobar");

            _repository.Save(cart);
        }

        public void Handle(RemoveItemFromCart command)
        {
            var cart = _repository.LoadById(command.CartId);

            cart.RemoveItem(command.ItemId);

            _repository.Save(cart);
        }
    }
}
