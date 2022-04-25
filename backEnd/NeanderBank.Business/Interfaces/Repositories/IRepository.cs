using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace NeanderBank.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable
    {
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetById(int id);
        Task<TEntity> GetByIdNoTracking(int id);
        Task<List<TEntity>> GetAll();
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Remove(int id);
        IQueryable<TEntity> GetQueryable();
        Task<int> SaveChanges();
    }
}