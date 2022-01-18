using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Migrations.Models;

namespace TravelAdvisor.Infrastructure.Migrations.Data
{
public class DbApplicationContext: DbContext
    {
        public DbApplicationContext(DbContextOptions<DbApplicationContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
