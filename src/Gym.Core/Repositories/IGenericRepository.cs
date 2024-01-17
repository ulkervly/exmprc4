using Gym.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        public DbSet<T> Table { get; }
        Task CraeteAsync(T entity); 
        void Delete(T entity);
        Task<int>CommitAsync();
        IQueryable<T> GetAllAysnc(params string[] includes);
        IQueryable<T> GetAllWhere(Expression<Func<T, bool>>? expression = null, params string[] includes);
        Task<T> GetSingleAsync(Expression<Func<T, bool>>? expression = null, params string[] includes);
    }
}
