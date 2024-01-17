using Gym.Business.Exceptions;
using Gym.Business.Services.Interfaces;
using Gym.Core.Entities;
using Gym.Core.Repositories;
using Gym.Data.Repositorires;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Services.Implementations
{
    public class TrainerService : ITrainerService

    {
        private readonly ITrainerRepository _trainerRepository;

        public TrainerService(ITrainerRepository  trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }
        public async Task Createasync(Trainer trainer)
        {
            if (trainer == null) throw new NullReferenceException();
            trainer.CreatedTime = DateTime.UtcNow;
            trainer.UpdatedTime = DateTime.UtcNow;
            await _trainerRepository.CraeteAsync(trainer);
            await _trainerRepository.CommitAsync();

        }

        public async Task Deleteasync(int Id)
        {
            if (Id<0)
            {
                throw new IdBelowZeroException();
            }
            var trainer = await _trainerRepository.GetSingleAsync(x=>x.Id==Id);
            if (trainer is null)
            {
                throw new NullReferenceException();
            }
            _trainerRepository.Delete(trainer);
            await _trainerRepository.CommitAsync();
            
        }

        public async Task<List<Trainer>> GetAllAsync(Expression<Func<Trainer, bool>>? expression = null, params string[]? includes)
        {
            return await _trainerRepository.GetAllWhere(expression, includes).ToListAsync();
        }

        public async Task<Trainer> GetByExpression(Expression<Func<Trainer, bool>>? expression = null, params string[]? includes)
        {
            return await _trainerRepository.GetAllWhere(expression,includes).FirstOrDefaultAsync();

        }

        public async Task Updateasync(Trainer trainer)
        {
            if(trainer==null) throw new NullReferenceException();
            var existtrainer=await _trainerRepository.GetSingleAsync(x=>x.Id==trainer.Id && !x.IsDeleted);
          existtrainer.UpdatedTime = trainer.UpdatedTime;
            existtrainer.Name = trainer.Name;
            existtrainer.MediaLinks = trainer.MediaLinks;
            await _trainerRepository.CraeteAsync(trainer);
            await _trainerRepository.CommitAsync();



        }
    }
}
