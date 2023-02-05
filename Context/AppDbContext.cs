using Microsoft.EntityFrameworkCore;
using Model;
using sorveteriaApi.Model;
using sorveteriaApi.Model.CarrinhoCompra;

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

        //tabela carrinho
        public DbSet<Carrinho> Carrinho { get; set; }

        //tabela item carrinho
        public DbSet<ItemCarrinho> ItensCarrinho { get; set; }
    }
}