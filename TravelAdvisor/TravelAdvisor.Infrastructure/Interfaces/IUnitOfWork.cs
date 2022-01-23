using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Migrations.Models;
using TravelAdvisor.Infrastructure.Repository;

namespace TravelAdvisor.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChanges();
        Repository<User> UserRepository
        {
            get;

        }
    }
}
