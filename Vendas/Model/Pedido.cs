using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Model
{
    public class Pedido
    {
        public static List<Pedido> Pedidos = new List<Pedido>();

        public Int32 codigo { get; set; }
        public DateTime Datapedito { get; set; }
        public Decimal Total { get; set; }

        public List<PedidoItem> Items { get; set; }

        public Pedido()
        {
            this.Items = new List<PedidoItem>();
        }
    }
}
