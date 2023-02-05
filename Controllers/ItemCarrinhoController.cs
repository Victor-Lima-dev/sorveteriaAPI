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
    public class ItemCarrinhoController : ControllerBase
    {
        //banco de dados
        private readonly AppDbContext _context;
        //constructor
        public ItemCarrinhoController(AppDbContext context)
        {
            _context = context;
        }
        
        //criar carrinhoItem
        [HttpPost]
        public async Task<ActionResult<ItemCarrinho>> CriarItemCarrinho()
        {
            //criar itemCarrinho
            var itemCarrinho = new ItemCarrinho();
            
            //adicionar itemCarrinho no banco de dados
            _context.ItensCarrinho.Add(itemCarrinho);

            //salvar alterações
            await _context.SaveChangesAsync();
            //retornar itemCarrinho
            return itemCarrinho;
        }

        //adicionar produto ao item
        [HttpPost("adicionarProduto")]
        public async Task<ActionResult<ItemCarrinho>> AdicionarProdutoItemCarrinho(int idProduto, int idItemCarrinho)
        {
            //buscar produto
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.ProdutoId == idProduto);
            //buscar itemCarrinho
            var itemCarrinho = await _context.ItensCarrinho.FirstOrDefaultAsync(i => i.ItemCarrinhoId == idItemCarrinho);
            //adicionar produto ao itemCarrinho
            itemCarrinho.Produto = produto;
            //salvar alterações
            await _context.SaveChangesAsync();
            //retornar itemCarrinho
            return itemCarrinho;
        }

    }
}