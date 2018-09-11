using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Model
{
    public class Produto
    {
        public static List<Produto> Produtos = new List<Produto>();

        public Int32 Codigo { get; set; }
        public String Descricao { get; set; }
        public Decimal Preco { get; set; }
    }
}
