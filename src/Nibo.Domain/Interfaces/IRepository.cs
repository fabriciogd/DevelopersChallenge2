using Nibo.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nibo.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity: Poco
    {
        Task<bool> AddRangeAsync(List<TEntity> entity);

        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate = null);
    }
}
