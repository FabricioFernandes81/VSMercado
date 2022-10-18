using ClientServer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClientServer.Context
{
    public class AppDbContext : IdentityDbContext<AppUsers>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base (options)
        {
        }

        /*
         -------Criação da Tabelas ------
         */
        
        public DbSet<Estados> estados { get; set; }
        public DbSet<Cidades> cidades { get; set; }
        public DbSet<Empresa> empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Estados>().HasData(
               new Estados { Id = 1, nome = "Acre", uf = "AC" },
               new Estados { Id = 2, nome = "Alagoas", uf = "AL" },
               new Estados { Id = 3, nome = "Amazonas", uf = "AM" });

            builder.Entity<Cidades>().HasData(
                new Cidades { Id = 1, nome = "Belém", EstadosId = 2 },
                new Cidades { Id = 2, nome = "Batalha", EstadosId = 2 },
                new Cidades { Id = 3, nome = "Belo Monte", EstadosId = 2 },
                new Cidades { Id = 4, nome = "Xapuri", EstadosId = 1 },
                new Cidades { Id = 5, nome = "Rio Branco", EstadosId = 1 },
                new Cidades { Id = 6, nome = "Sena Madureira", EstadosId = 1 },
                new Cidades { Id = 7, nome = "Barreirinha", EstadosId = 3 },
                new Cidades { Id = 8, nome = "Barcelos", EstadosId = 3 },
                new Cidades { Id = 9, nome = "Atalaia do Norte", EstadosId = 3 });
            base.OnModelCreating(builder);
        }
    }
}
