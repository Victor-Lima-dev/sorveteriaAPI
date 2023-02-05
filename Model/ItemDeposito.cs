using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace sorveteriaApi.Model
{
    public class ItemDeposito
    {
        public int ItemDepositoId { get; set; }
        public int Quantidade { get; set; }
        public Produto Produto { get; set; }
    }
}