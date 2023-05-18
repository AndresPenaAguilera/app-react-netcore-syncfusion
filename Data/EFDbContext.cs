using Data.ModelBuilders;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Data
{
    public class EFDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public EFDbContext(DbContextOptions<EFDbContext> options): base (options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderModelBuilder());
        }
    }
}
