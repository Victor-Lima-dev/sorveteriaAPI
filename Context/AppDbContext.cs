using Microsoft.EntityFrameworkCore;
using Model;
using sorveteriaApi.Model;

namespace Context
{
    public class AppDbContext : DbContext
    {
        //constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //tabela deposito
        public DbSet<Deposito> Deposito { get; set; }
        //tabela produto
        public DbSet<Produto> Produtos { get; set; }
    }
}