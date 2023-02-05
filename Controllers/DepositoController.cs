using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using sorveteriaApi.Model;

namespace sorveteriaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepositoController : ControllerBase
    {
        //banco de dados
        private readonly AppDbContext _context;



        //constructor com o deposito
        public DepositoController(AppDbContext context)
        {
            _context = context;

        }

    
        //adicionar um produto ao deposito
        [HttpPost("AdicionarProduto")]
        public async Task<ActionResult<Deposito>> AdicionarProduto(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            var deposito = _context.Deposito.FirstOrDefault(d => d.DepositoId == 1);

            if (deposito.Produtos == null)
            {
                deposito.Produtos = new List<Produto>();
            }

           

                if (deposito.Produtos.FirstOrDefault(p => p.ProdutoId == id) != null)
                {
                   var produto1 = deposito.Produtos.FirstOrDefault(p => p.ProdutoId == id);
                   produto1.Quantidade += 1;
                   await _context.SaveChangesAsync();
                    return Ok(deposito);
                }
                //adiciona o produto
                deposito.Produtos.Add(produto);
                deposito.Quantidade = deposito.Produtos.Count();
                //salva as alterações
                await _context.SaveChangesAsync();
                //retorna o produto
                return deposito;

        }

        //remover um produto do deposito
        [HttpPost("RemoverProduto")]
        public async Task<ActionResult<Deposito>> RemoverProduto(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            var deposito = _context.Deposito.FirstOrDefault(d => d.DepositoId == 1);

            //remove o produto
            deposito.Produtos.Remove(produto);
            //salva as alterações
            await _context.SaveChangesAsync();
            //retorna o produto
            return deposito;
        }








    }
}