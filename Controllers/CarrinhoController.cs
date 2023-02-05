using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sorveteriaApi.Model.CarrinhoCompra;

namespace sorveteriaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrinhoController : ControllerBase
    {
        //instanciar banco de dados
        private readonly AppDbContext _context;

        //constructor
        public CarrinhoController(AppDbContext context)
        {
            _context = context;
        }

        //criar carrinho
        //assincron
        [HttpPost]
        public async Task<ActionResult<Carrinho>> CriarCarrinho()
        {
            //criar carrinho
            var carrinho = new Carrinho();
            carrinho.Itens = new List<ItemCarrinho>();
            //adicionar carrinho no banco de dados
            _context.Carrinho.Add(carrinho);
            //salvar alterações
            await _context.SaveChangesAsync();
            //retornar carrinho
            return carrinho;
        }

        //ver carrinho
        //assincrono
        [HttpGet("{id}")]
        public async Task<ActionResult<Carrinho>> VerCarrinho(int id)
        {
            //buscar carrinho
             var carrinho = await _context.Carrinho.FirstAsync(c => c.CarrinhoId == 1);
            //var itemCarrinho = await _context.ItensCarrinho.FirstAsync(i => i.ItemCarrinhoId == 1);
            //retornar carrinho
            return carrinho;
        }

        //adicionar item ao carrinho
        //assincrono
        [HttpPost("adicionarItem")]
        public async Task<ActionResult<Carrinho>> AdicionarItemCarrinho(int idCarrinho)
        {
           
            //buscar carrinho
            var carrinho = await _context.Carrinho.FirstOrDefaultAsync(c => c.CarrinhoId == idCarrinho);
            carrinho.Itens = new List<ItemCarrinho>();
            return carrinho;
        }

        //adicionar um produto ao carrinho
        //assincrono
        [HttpPost("adicionarProduto")]
        public async Task<ActionResult<Carrinho>> AdicionarProdutoCarrinho(int idProduto)
        {
            //buscar produto
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.ProdutoId == idProduto);
            //buscar carrinho
            var carrinho = await _context.Carrinho.FirstOrDefaultAsync(c => c.CarrinhoId == 4);

            var verificarProduto = carrinho.Itens.FirstOrDefault(i => i.Produto.ProdutoId == idProduto);

            if(verificarProduto != null)
            {
                verificarProduto.Quantidade++;
                _context.ItensCarrinho.Update(verificarProduto);
                _context.SaveChanges();
                return carrinho;
            }
            else
            {
                //criar itemCarrinho
                var itemCarrinho = new ItemCarrinho();
                itemCarrinho.Produto = produto;
                itemCarrinho.Quantidade = 1;
                //adicionar itemCarrinho no banco de dados
                _context.ItensCarrinho.Add(itemCarrinho);
                //salvar alterações
                await _context.SaveChangesAsync();

                if (carrinho.Itens == null)
                {
                    carrinho.Itens = new List<ItemCarrinho>();
                }

                //adicionar item ao carrinho
                carrinho.Itens.Add(itemCarrinho);
                _context.Carrinho.Update(carrinho);
                _context.SaveChanges();
                return carrinho;
            }


           
        }

        

    }
}