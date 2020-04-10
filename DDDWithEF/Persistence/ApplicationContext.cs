using DDDWithEF.Models;
using DDDWithEF.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDWithEF.Persistence
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public DbSet<Dossier> Dossiers { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
    }
}
