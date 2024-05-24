using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoverFornecedor
{
    public class ExcluirFornecedor
    {
        public static void RemoverFornecedor()
        {
            Console.WriteLine("\nDigite o ID do Fornecedor que deseja remover: ");
            int idFornecedor = Convert.ToInt32(Console.ReadLine());

            string stringDeConexao = @"Data Source=DESKTOP-HUTS0O2;Initial Catalog=BD_FAZENDA;Integrated Security=True;";

            string consulta = "DELETE FROM Fornecedor WHERE ID = @ID";

            using (SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexao))
                {
                    comando.Parameters.AddWithValue("@ID", idFornecedor);

                    conexao.Open();
                    int linhasAfetadas = comando.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        Console.WriteLine("Fornecedor removido com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Nenhum fornecedor foi encontrado com o ID fornecido.");
                    }
                }
            }
        }
    }
}


