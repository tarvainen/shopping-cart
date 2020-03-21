using System.Linq;
using System.Collections.Generic;
using System;

namespace ShoppingCart.Events
{
    public class EventStore : IEventStore
    {
        private Dictionary<Guid, List<IEvent>> _store;

        public EventStore()
        {
            _store = new Dictionary<Guid, List<IEvent>>();
        }

        public void AddEvents(Guid aggregateId, IEnumerable<IEvent> events)
        {
            List<IEvent> currentEvents;

            if (!_store.TryGetValue(aggregateId, out currentEvents))
            {
                currentEvents = new List<IEvent>();
                _store.Add(aggregateId, currentEvents);
            }

            events.ToList()
                .ForEach(e => currentEvents.Add(e));
        }

        public IEnumerable<IEvent> GetEvents(Guid aggregateId)
        {
            List<IEvent> events;

            if (!_store.TryGetValue(aggregateId, out events))
            {
                throw new ArgumentException("No events found for aggregate");
            }

            return events;
        }
    }
}
