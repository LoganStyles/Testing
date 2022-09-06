using Microsoft.EntityFrameworkCore;

namespace Artists
{

    public partial class ArtistsContext : DbContext
    {

        public ArtistsContext() { }

        public ArtistsContext(DbContextOptions<ArtistsContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("data source=output/Artists.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

    }
}