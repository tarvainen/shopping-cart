using System.Linq;
using System.Collections.Generic;
using System;
using Xunit;
using ShoppingCart.Events;

namespace ShoppingCart.Test
{
    class TestEvent : IEvent
    {
        public string Text { get; }

        public TestEvent(string text = null)
        {
            Text = text;
        }
    }

    public class EventStoreTest
    {
        [Fact]
        public void EventStore_ThrowsExceptionIfNoEventsFoundForAggregate()
        {
            var store = new EventStore();

            Assert.Throws<ArgumentException>(() => store.GetEvents(Guid.NewGuid()));
        }

        [Fact]
        public void EventStore_AddEventsToEmptyListInitialisesIt()
        {
            var guid = Guid.NewGuid();
            var store = new EventStore();

            store.AddEvents(guid, new List<IEvent>
            {
                new TestEvent(),
                new TestEvent(),
            });

            var events = store.GetEvents(guid);

            Assert.Equal(2, events.Count());
        }

        [Fact]
        public void EventStore_AddEventsToExistingListAppendsThem()
        {
            var guid = Guid.NewGuid();
            var store = new EventStore();

            store.AddEvents(guid, new List<IEvent> { new TestEvent("1"), new TestEvent("2") });
            store.AddEvents(guid, new List<IEvent> { new TestEvent("3") });

            var events = store.GetEvents(guid);

            Assert.Equal(3, events.Count());

            Assert.Equal("1", ((TestEvent)events.ElementAt(0)).Text);
            Assert.Equal("2", ((TestEvent)events.ElementAt(1)).Text);
            Assert.Equal("3", ((TestEvent)events.ElementAt(2)).Text);
        }
    }
}
