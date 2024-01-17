using Gym.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Services.Interfaces
{
    public interface ITrainerService
    {
        Task Createasync(Trainer trainer);
        Task Updateasync(Trainer trainer);
        Task Deleteasync(int Id);
        Task <List<Trainer>> GetAllAsync(Expression<Func<Trainer, bool>>? expression = null, params string[]? includes);
        Task<Trainer> GetByExpression(Expression<Func<Trainer,bool>>? expression=null,params string[]? includes);
    }
}
