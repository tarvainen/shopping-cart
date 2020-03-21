using System;
using ShoppingCart.Data;

namespace ShoppingCart.Repository
{
    public interface IRepository<T> where T : Aggregate
    {
        void Save(Aggregate aggregate);
        T LoadById(Guid id);
    }
}
