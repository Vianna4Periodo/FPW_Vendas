using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Model;

namespace Vendas.DbConfig.DAO
{
    public class ProdutoDAO
    {
        private MySqlConnection conexaoMySql;

        public ProdutoDAO(MySqlConnection conexaoMySql)
        {
            this.conexaoMySql = conexaoMySql;
        }

        public List<Produto> BuscarTodos()
        {
            try
            {
                var produtos = new List<Produto>();
                var sql = "select * from produto";

                //armazena os dados
                // usa somente para select
                var dataSet = new DataSet();

                var query = new MySqlDataAdapter(sql, conexaoMySql);
                query.Fill(dataSet);

                //Coloca dentro de item os dados da tabela do select
                // O [0] - estou fazendo select de uma tabela, e percorre o list e 
                // converte para lista.
                foreach(var item in dataSet.Tables[0].AsEnumerable().ToList())
                {
                    var produto = new Produto()
                    {
                        Codigo = Convert.ToInt32(item["codigo"]),
                        Descricao = item["descricao"].ToString(),
                        Preco = Convert.ToDecimal(item["preco"])
                    };

                    produtos.Add(produto);
                }

                return produtos;


            }catch(Exception ex)
            {
                throw new Exception("Não foi possivél buscar todos os produtos!", ex);
            }
            finally
            {
                if (conexaoMySql.State == ConnectionState.Open)
                    conexaoMySql.Close();
            }
        }
    }
}
