using Collision.Platform.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Collision.Platform.DataAccess
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected AppDbContext _dbContext;

        public BaseRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        public virtual T Add(T entity)
        {
            return _dbContext
                .Add(entity)
                .Entity;
        }

        public virtual IEnumerable<T> Search(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>()
                .AsQueryable()
                .Where(predicate).ToList();
        }

        public virtual T Get(int id)
        {
            return _dbContext.Find<T>(id);
        }

        public virtual IEnumerable<T> All()
        {
            return _dbContext.Set<T>()
                .ToList();
        }

        public virtual T Update(T entity)
        {
            return _dbContext.Update(entity)
                .Entity;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Get(id);
            _dbContext.Remove(entity);
        }
    }
}
