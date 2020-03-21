using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using ShoppingCart.Events;
using System.Reflection;
using ShoppingCart.Util;

namespace ShoppingCart.Data
{
    public interface IAggregate
    {
        void LoadFromHistory(IEnumerable<IEvent> events);
        IEnumerable<IEvent> GetEvents();
        void ClearEvents();
    }

    public class Aggregate : IAggregate
    {
        public Guid Id { get; protected set; }
        private readonly List<IEvent> _events = new List<IEvent>();

        public void LoadFromHistory(IEnumerable<IEvent> events)
        {
            events.ToList().ForEach(x => ApplyChange(x, false));
        }

        public IEnumerable<IEvent> GetEvents()
        {
            return _events;
        }

        public void ClearEvents()
        {
            _events.Clear();
        }

        protected void ApplyChange(IEvent evt, bool dispatch = true)
        {
            DynamicApplyEvent(evt);

            if (dispatch)
            {
                _events.Add(evt);
            }
        }

        private void DynamicApplyEvent(IEvent evt)
        {
            this.Invoke("Apply", new object[] { evt });
        }
    }
}
