using Microsoft.EntityFrameworkCore;
using ProjectStructure.Domain;
using ProjectStructure.Infrastructure.MyDomainDAL.MapConfig;

namespace ProjectStructure.Infrastructure.MyDomainDAL
{
    public class MyDomainDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PersonMap());
        }
    }
}
