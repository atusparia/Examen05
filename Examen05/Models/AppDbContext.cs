using Microsoft.EntityFrameworkCore;

namespace Examen05.Models
{
    public class AppDbContext:DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source = SRVMIO;" +
                    "initial catalog=VentaDB; User Id=usMio; Pwd=Rcm123456;" +
                    "TrustServerCertificate=true");
        }
    }
}
