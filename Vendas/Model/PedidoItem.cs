using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Model
{
    public class PedidoItem
    {
        public Produto produto { get; set; }
        public Double Quantidade { get; set; }
    }
}
