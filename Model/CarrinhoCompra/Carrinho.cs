using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sorveteriaApi.Model.CarrinhoCompra
{
    public class Carrinho
    {
        public int CarrinhoId { get; set; }
        public List<ItemCarrinho> Itens { get; set; }
        public double ValorTotal { get; set; }

        public void SomarValorTotal()
        {
            ValorTotal = 0;
            foreach (var item in Itens)
            {
                ValorTotal += item.ValorTotalItem;
            }
        }
    }
}