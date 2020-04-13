using Microsoft.EntityFrameworkCore;
using SystemBibloteka.Models;
using SystemBibloteka.Models.Configurations;

namespace SystemBibloteka.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new LibraryConfigurations());
            modelBuilder.ApplyConfiguration(new BookConfigurations());
            modelBuilder.ApplyConfiguration(new SchoolConfigurations());
        }

        public DbSet<Library> Libraries { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<School> Schools { get; set; }
    }
}
