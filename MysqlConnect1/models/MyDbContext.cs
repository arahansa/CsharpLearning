using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysqlConnect1.models
{
    class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TestUser> TestUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Environment.GetEnvironmentVariable("dbInfoEntityFramework"));
        }
    }
}
