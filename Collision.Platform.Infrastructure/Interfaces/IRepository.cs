using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Collision.Platform.Infrastructure.Interfaces
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        T Get(int id);
        IEnumerable<T> All();
        IEnumerable<T> Search(Expression<Func<T, bool>> predicate);
        void SaveChanges();
        void Delete(int id);
    }
}
