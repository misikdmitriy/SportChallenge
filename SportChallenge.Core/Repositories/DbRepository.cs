using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportChallenge.Core.DbContexts;
using SportChallenge.Core.Models;
using SportChallenge.Core.Repositories.Contracts;

namespace SportChallenge.Core.Repositories
{
    public class DbRepository<TEntity> : IDbRepository<TEntity>
            where TEntity : class, IIDentifiable
    {
        private readonly SportContext _context;

        public DbRepository(SportContext context)
        {
            _context = context;
        }

        public async Task<TEntity[]> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetQuery(_context).Where(predicate).ToArrayAsync();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetQuery(_context).SingleOrDefaultAsync(predicate);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        protected virtual IQueryable<TEntity> GetQuery(SportContext context)
        {
            return context.Set<TEntity>();
        }
    }
}
