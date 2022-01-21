using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Migrations.Models;

namespace TravelAdvisor.Infrastructure.Migrations.Interfaces
{
   public interface IRepository
    {
        public interface IRepository<TEntity> where TEntity : class
        {
            Task AddAsync(TEntity entity);
            Task AddRangeAsync(IEnumerable<TEntity> entities);
            Task RemoveAsync(TEntity entity);
            Task UpdateAsync(TEntity entity);
            Task RemoveRangeAsync(IEnumerable<TEntity> entities);
            Task<TEntity> GetByGuidAsync(Guid id);
            Task<IEnumerable<TEntity>> GetAllAsync();
            Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);



            //Merran
            void Add(User user);
            User GetByEmail(string email); //User istället för void efetrsom methoden returnerar User istället för ingenting 
            User GetByEmailAndPassword(string email, string password);

            //method som sparar cookie
            ClaimsIdentity Authenticate(string userName);

        }
    }
}
