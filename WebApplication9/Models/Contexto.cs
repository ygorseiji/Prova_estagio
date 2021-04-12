using Microsoft.EntityFrameworkCore;

namespace WebApplication9.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Vendedor> dbVendedor { get; set; }
        public DbSet<Cliente> dbCliente { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {

        }
    }
}
