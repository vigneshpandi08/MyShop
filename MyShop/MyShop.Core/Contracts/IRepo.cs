using MyShop.Core.Models;
using System;
namespace MyShop.Core.Contracts
{
    interface IRepo<T> where T : BaseEntity
    {
        System.Linq.IQueryable<T> Collection();
        void Commit();
        void Delete(string Id);
        void DoSomething();
        T Find(string Id);
        void Insert(T t);
        void Update(T t);
    }
}
