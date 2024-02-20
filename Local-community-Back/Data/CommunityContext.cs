using Local_community_Back.Model;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;

namespace Local_community_Back.Data
{
    public class CommunityContext : DbContext
    {
        public CommunityContext(DbContextOptions<CommunityContext> options) : base(options)
        {
        }

        public DbSet<Appeal> Appeal { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Finances> Finances { get; set; }
        public DbSet<Infrastructure> Infrastructure { get; set; }
        public DbSet<Map> Map { get; set; }
        public DbSet<Subscription> Subscription {get; set;}
        public DbSet<News> News { get; set; }
        public DbSet<ProjectInfrasrtructure> ProjectInfrasrtructure { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
        }
    }
}
