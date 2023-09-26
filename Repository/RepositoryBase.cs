using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext repositoryContext;

        public RepositoryBase(RepositoryContext context) => repositoryContext = context;

        public IQueryable<T> FindAll(bool trackingChanges)
        {
            return trackingChanges
                ? repositoryContext.Set<T>()
                : repositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackingChanges)
        {
            return trackingChanges
                ? repositoryContext.Set<T>().Where(expression)
                : repositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity) => repositoryContext.Set<T>().Add(entity);
        public void Update(T entity) => repositoryContext.Set<T>().Update(entity);
        public void Delete(T entity) => repositoryContext.Set<T>().Remove(entity);
    }
}
