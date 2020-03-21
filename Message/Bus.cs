using ShoppingCart.Command;
using ShoppingCart.Events;
using ShoppingCart.Util;

namespace ShoppingCart.Message
{
    public class Bus : IBus
    {
        private readonly ICommandHandler _commandHandler;

        public Bus(ICommandHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public void Dispatch(ICommand cmd)
        {
            _commandHandler.Invoke("Handle", new object[] { cmd });
        }

        public void Publish(IEvent evt)
        {
            throw new System.NotImplementedException();
        }
    }
}
