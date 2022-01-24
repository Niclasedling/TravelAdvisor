using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Interfaces;
using TravelAdvisor.Infrastructure.Migrations.Data;

namespace TravelAdvisor.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbApplicationContext context;

        public Repository(DbApplicationContext context)
        {
            this.context = context;
        }


        public async Task AddAsync(TEntity entity) => await context.Set<TEntity>().AddAsync(entity);

        public async Task AddRangeAsync(IEnumerable<TEntity> entities) => await context.Set<TEntity>().AddRangeAsync(entities);

        public async Task RemoveAsync(TEntity entity) => await Task.Run(() => { context.Set<TEntity>().Remove(entity); });


        public async Task UpdateAsync(TEntity entity) => await Task.Run(() => { context.Set<TEntity>().Update(entity); });



        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities) => await Task.Run(() => { context.Set<TEntity>().RemoveRange(entities); });

        public async Task<TEntity> GetByGuidAsync(Guid id) => await context.Set<TEntity>().FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await Task.Run(() => { return context.Set<TEntity>().ToList(); });

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate) => await Task.Run(() => { return context.Set<TEntity>().Where(predicate); });


    }
}
