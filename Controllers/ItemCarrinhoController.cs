using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Context;
using Microsoft.AspNetCore.Mvc;
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

    }
}