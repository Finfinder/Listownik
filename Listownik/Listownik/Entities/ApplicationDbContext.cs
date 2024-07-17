using Microsoft.EntityFrameworkCore;

namespace Listownik.Entities
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<WpisListyEntity> WpisyListy { get; set; } = default!;
        public DbSet<KategorieEntity> Kategorie { get; set; } = default!;
        public DbSet<ListyEntity> Listy { get; set; } = default!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Listownik;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
