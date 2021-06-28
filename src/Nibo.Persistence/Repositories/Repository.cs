using Microsoft.EntityFrameworkCore;
using Nibo.Application.Context;
using Nibo.Domain.Base;
using Nibo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nibo.Persistence.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Poco
    {
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(INiboDBContext db)
        {
            DbSet = db.Set<TEntity>();
        }

        public async Task<bool> AddRangeAsync(List<TEntity> entity)
        {
            await DbSet.AddRangeAsync(entity);

            return true;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await DbSet.AnyAsync(predicate);
        }
    }
}
