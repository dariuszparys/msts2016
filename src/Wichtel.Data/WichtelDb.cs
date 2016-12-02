using System;
using Microsoft.EntityFrameworkCore;

namespace Wichtel.Data
{
    public class WichtelDb : DbContext
    {
        public DbSet<Tweet> Tweets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            var connection = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_wichteldb");
            optionsBuilder.UseSqlServer(connection);
        }
    }
}