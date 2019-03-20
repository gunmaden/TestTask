using DBRepository.Configurations;
using Microsoft.EntityFrameworkCore;
using Models.EntityModels;

namespace DBRepository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BaseIdConfiguration<User>());
            modelBuilder.ApplyConfiguration(new BaseIdConfiguration<Position>());
            modelBuilder
                .HasPostgresExtension("uuid-ossp")
                .ForNpgsqlUseIdentityAlwaysColumns();
        }
    }
}