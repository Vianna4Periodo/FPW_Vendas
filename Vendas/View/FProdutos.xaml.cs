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
using Vendas.DbConfig;
using Vendas.Model;

namespace Vendas.View
{
    /// <summary>
    /// Interaction logic for FProdutos.xaml
    /// </summary>
    public partial class FProdutos : Window
    {
        public FProdutos()
        {
            InitializeComponent();
        }


        public void Execute()
        {
            // trazendo os dados do banco
            tblProdutos.ItemsSource = DbFactoy.Instance.ProdutoDAO.BuscarTodos();
         
            this.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void botaoAdd_Click(object sender, RoutedEventArgs e)
        {
            var frmAddProduto = new FAddEdtProduto();
            var produto = frmAddProduto.Execute();

            if(produto != null)
            {
                Produto.Produtos.Add(produto);
                tblProdutos.ItemsSource = null;
                tblProdutos.ItemsSource = Produto.Produtos;
            }
        }

        private void botaoExcluir_Click(object sender, RoutedEventArgs e)
        {
            if(tblProdutos.SelectedItems.Count > 0)
            {
                var o = tblProdutos.SelectedItems[0];

                var produto = (Produto)o;

                if (MessageBox.Show("Deseja apagar " + produto.Descricao + "?",
                    "Deletar", MessageBoxButton.YesNo, MessageBoxImage.Question)
                     == MessageBoxResult.Yes)

                    Produto.Produtos.Remove(produto);

                tblProdutos.ItemsSource = null;
                tblProdutos.ItemsSource = Produto.Produtos;

            }
            else
            {
                MessageBox.Show("Selecione um Produto");
            }
        }
    }
}
