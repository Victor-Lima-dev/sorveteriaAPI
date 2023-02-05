using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace sorveteriaApi.Model.CarrinhoCompra
{
    public class ItemCarrinho
    {
        public int ItemCarrinhoId { get; set; }
        public int Quantidade { get; set; }
        public Produto? Produto { get; set; }
        public double ValorTotalItem { get; set; }

        //carrinho id
        //public int CarrinhoId { get; set; }

        public void CalcularValorTotalItem()
        {
            ValorTotalItem = Produto.Preco * Quantidade;
        }      

    }
}