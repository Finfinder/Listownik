using Microsoft.AspNetCore.Hosting;
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
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("ListownikDatabase");
                optionsBuilder.UseSqlServer(connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
