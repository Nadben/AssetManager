using AssetManager.Domain.Entities;
using AssetManager.Domain.ValueObject;
using AssetManager.Infrastructure.Config;
using AssetManager.Infrastructure.Options;
using AssetManager.Shared.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AssetManager.Infrastructure
{
    public class AssetManagerContext : DbContext
    {
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Recorder> Recorders { get; set; }
        public DbSet<Owner> Owners { get; set; }    
        public DbSet<User> Users { get; set; }

        private readonly IConfiguration _configuration;

        public AssetManagerContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetOptions<PostgresOptions>("Postgres").connectionString,
                o => o.MigrationsAssembly("AssetManager.Api"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>(i =>
            {
                i.HasKey("_id");
                i.Property(j => j.Email);
                i.Property(j => j.Name);
                i.Property(j => j.Role);
            });

            var configuration = new Configuration();

            modelBuilder.ApplyConfiguration<Asset>(configuration);
            modelBuilder.ApplyConfiguration<Area>(configuration);
            modelBuilder.ApplyConfiguration<Camera>(configuration);
            modelBuilder.ApplyConfiguration<Recorder>(configuration);
            modelBuilder.ApplyConfiguration<User>(configuration);
        }
    }
}