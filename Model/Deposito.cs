using Model;

namespace sorveteriaApi.Model
{
    public class Deposito
    {
        //id
        public int DepositoId { get; set; }
        //produtos
        public List<Produto> Produtos { get; set; }
        //quantidade
        public int Quantidade { get; set; }

        


    }
}