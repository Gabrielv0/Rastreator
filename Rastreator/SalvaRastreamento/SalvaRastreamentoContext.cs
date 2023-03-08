using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace SalvaRastreamento
{
    internal class SalvaRastreamentoContext : DbContext

    {
         public DbSet<User> Users { get; set; }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=rastreator;Trusted_Connection=True;persist security info=True;");
         }
    }
}
