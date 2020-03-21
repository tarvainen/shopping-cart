using System.Collections.Generic;
using System;

namespace ShoppingCart.Events
{
    public interface IEventStore
    {
        void AddEvents(Guid aggregateId, IEnumerable<IEvent> events);
        IEnumerable<IEvent> GetEvents(Guid aggregateId);
    }
}
