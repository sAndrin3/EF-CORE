using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EF_CORE{
    public class ApplicationDBContext : DbContext{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=Another2; User id=SA; Password=S@ndrine1!; Encrypt=True; TrustServerCertificate=True");
        }

        public DbSet<Tour> Tours {get; set; }
        public DbSet<Traveller> Travellers {get; set; }
    }
}

