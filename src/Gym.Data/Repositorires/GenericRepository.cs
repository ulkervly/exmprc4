
using Gym.Core.Entities;
using Gym.Core.Repositories;
using Gym.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Data.Repositorires
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public  async Task<int> CommitAsync()
        {
          return await _context.SaveChangesAsync();
        }

        public async Task CraeteAsync(T entity)
        {
           await Table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public IQueryable<T> GetAllAysnc(params string[] includes)
        {
            var query=_getQuery(includes);
            return query;
        }

        public  IQueryable<T> GetAllWhere(Expression<Func<T, bool>>? expression = null, params string[] includes)
        {
            var query=_getQuery(includes);
            return  expression is not null ? query.Where(expression) :  query;
        }

        public Task<T> GetSingleAsync(Expression<Func<T, bool>>? expression = null, params string[] includes)
        {
           var query=_getQuery(includes);
            return expression is not null ? query.Where(expression).FirstOrDefaultAsync() : query.FirstOrDefaultAsync();
        }
        private IQueryable<T> _getQuery(params string[] includes)
        {
            var query=Table.AsQueryable();
            if (includes!=null && includes.Length>0)
            {
                foreach (var item in includes)
                {
                    query=query.Include(item);
                }
            }
            return query;
        }
    }
}
