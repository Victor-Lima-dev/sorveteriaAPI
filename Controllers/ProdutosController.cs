using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace sorveteriaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        //banco de dados
        private readonly AppDbContext _context;
        //constructor com o produto
        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        //GET /produtos
        //assincrono
        [HttpGet]
        public async Task<ActionResult<List<Produto>>> Get()
        {
            //retorna a lista de produtos
            return await _context.Produtos.ToListAsync();
        }

        //POST /produtos/RegistrarProduto
        //assincrono
        [HttpPost("RegistrarProduto")]
        public async Task<ActionResult<Produto>> Post(Produto produto)
        {
            //adiciona o produto
            _context.Produtos.Add(produto);
            //salva as alterações
            await _context.SaveChangesAsync();
            //retorna o produto
            return produto;
        }

        //POST /produtos/RemoverProduto
        //assincrono
        [HttpPost("RemoverProduto")]
        public async Task<ActionResult<Produto>> RemoverProduto(Produto produto)
        {
            //remove o produto
            _context.Produtos.Remove(produto);
            //salva as alterações
            await _context.SaveChangesAsync();
            //retorna o produto
            return produto;
        }

        //PUT /produtos/AtualizarProduto
        //assincrono
        [HttpPut("AtualizarProduto")]
        public async Task<ActionResult<Produto>> AtualizarProduto(Produto produto)
        {
            //atualiza o produto
            _context.Produtos.Update(produto);
            //salva as alterações
            await _context.SaveChangesAsync();
            //retorna o produto
            return produto;
        }


    }
}