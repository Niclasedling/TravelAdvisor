using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Migrations.Data;
using TravelAdvisor.Infrastructure.Migrations.Interfaces;

namespace TravelAdvisor.Infrastructure.Migrations.Repository
{
    public class UserRepository : Repository<Models.User>, IUserRepository
    {
        public UserRepository(DbApplicationContext context) : base(context)
        {
        }

        public DbApplicationContext DBEntities
        {
            get
            {
                return context as DbApplicationContext;
            }
        }

    }
}
