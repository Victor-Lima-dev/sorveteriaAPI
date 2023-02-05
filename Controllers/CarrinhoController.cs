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
            var carrinho = await _context.Carrinho.FirstOrDefaultAsync(c => c.CarrinhoId == id);
            //retornar carrinho
            return carrinho;
        }

        //adicionar item ao carrinho
        //assincrono
        [HttpPost("adicionarItem")]
        public async Task<ActionResult<Carrinho>> AdicionarItemCarrinho(int idCarrinho)
        {
            //buscar itemCarrinho
            var itemCarrinho = await _context.ItensCarrinho.FirstOrDefaultAsync(i => i.ItemCarrinhoId == idCarrinho);
            //buscar carrinho
            var carrinho = await _context.Carrinho.FirstOrDefaultAsync(c => c.CarrinhoId == 4);

            if(carrinho.Itens == null)
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