using System;
using ShoppingCart.Data;
using ShoppingCart.Events;

namespace ShoppingCart.Repository
{
    public class Repository<T> : IRepository<T> where T : Aggregate, new()
    {
        private readonly IEventStore _store;

        public Repository(IEventStore store)
        {
            _store = store;
        }

        public T LoadById(Guid id)
        {
            var aggregate = new T();

            aggregate.LoadFromHistory(_store.GetEvents(id));

            return aggregate;
        }

        public void Save(Aggregate aggregate)
        {
            _store.AddEvents(aggregate.Id, aggregate.GetEvents());
        }
    }
}
