using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    class LibraryContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LibraryDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Odunc> Oduncverilenler { get; set; }
    }
}
