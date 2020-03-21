using ShoppingCart.Command;
using ShoppingCart.Events;

namespace ShoppingCart.Message
{
    public interface IBus
    {
        void Dispatch(ICommand cmd);
        void Publish(IEvent evt);
    }
}
