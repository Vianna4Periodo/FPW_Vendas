using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.DbConfig.DAO;

namespace Vendas.DbConfig
{
    public class DbFactoy
    {
        private static DbFactoy _instance = null;

        protected MySqlConnection ConexaoMySql;
        public ProdutoDAO ProdutoDAO { get; set; }

        private DbFactoy()
        {
            Conectar();
            this.ProdutoDAO = new ProdutoDAO(ConexaoMySql);
        }

        public static DbFactoy Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DbFactoy();

                return _instance;
            }
        }

        private void Conectar()
        {
            try
            {
                var connectionString = "SERVER=localhost;DATABASE=venda;UID=root;PASSWORD=!@#$1234";
                ConexaoMySql = new MySqlConnection(connectionString);

                ConexaoMySql.Open();

            }catch(Exception ex)
            {
                throw new Exception("Não foi possivel conectar ao Banco de Dados.", ex);
            }

            finally
            {
                if(ConexaoMySql.State == ConnectionState.Open)
                ConexaoMySql.Close();
            }
        }
    }
}
