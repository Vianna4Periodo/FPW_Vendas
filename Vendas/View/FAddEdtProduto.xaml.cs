using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Vendas.Model;

namespace Vendas.View
{
    /// <summary>
    /// Interaction logic for FAddEdtProduto.xaml
    /// </summary>
    public partial class FAddEdtProduto : Window
    {
        private Produto tempProduto;

        public FAddEdtProduto()
        {
            InitializeComponent();
        }

        public Produto Execute()
        {
            this.tempProduto = null;
            this.ShowDialog();
            return this.tempProduto;
        }

        public Produto Execute(Produto produto)
        {
            this.tempProduto = produto;

            txtDescricao.Text = produto.Descricao;
            txtPreco.Text = produto.Preco.ToString();

            this.ShowDialog();
            return this.tempProduto;
        }


        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            if(this.tempProduto == null)
            {
                this.tempProduto = new Produto()
                {
                    Descricao = txtDescricao.Text,
                    Preco = Convert.ToDecimal(txtPreco.Text)
                };
            }
            else
            {
                this.tempProduto.Descricao = txtDescricao.Text;
                this.tempProduto.Preco = Convert.ToDecimal(txtPreco.Text);
            }

                    
        

            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.tempProduto = null;
            this.Close();
        }


    }
}
