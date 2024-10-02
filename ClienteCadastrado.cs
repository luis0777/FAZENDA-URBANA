using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostrarClientes
{
    public class ClienteCadastrado
    {
        public static void MostrarClientes()
        {
            string stringDeConexao = @"Data Source=DESKTOP-HUTS0O2;Initial Catalog=BD_FAZENDA;Integrated Security=True;";

            string consulta = "SELECT * FROM Cliente"; // Consulta SQL para selecionar todos os clientes

            using (SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexao))
                {
                    conexao.Open();
                    using (SqlDataReader leitor = comando.ExecuteReader())
                    {
                        Console.WriteLine("\nClientes cadastrados:\n");
                        while (leitor.Read())
                        {
                            Console.WriteLine($"ID: {leitor["ID"]}, Nome: {leitor["NomeCliente"]}, CPF: {leitor["CPF"]}, Email: {leitor["Email"]}");
                        }
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
