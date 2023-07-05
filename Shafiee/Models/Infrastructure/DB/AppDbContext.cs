using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shafiee.Models.Entities;

namespace Shafiee.Models.Infrastructure.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<ActivityType> ActivityTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Shafiee;User ID=sa;Password=Pass1234;MultipleActiveResultSets=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
