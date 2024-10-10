using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasCli;

namespace FazerLogin
{
    public class ClienteFazerLogin
    {
        public static void FazerLogin()
        {
            bool loginSucesso = false;

            while (!loginSucesso)
            {
                Console.WriteLine("Faça seu login:");

                Console.Write("CPF: ");
                string CPF = Console.ReadLine();
                Console.Write("Senha: ");
                string senha = Console.ReadLine();

                if (ValidarLogin(CPF, senha))
                {
                    Console.WriteLine("Login bem-sucedido!");
                    loginSucesso = true;
                }
                else
                {
                    Console.WriteLine("CPF ou senha incorretos. Tente novamente.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            // Coloque aqui o código para redirecionar o usuário para a próxima etapa do programa
            Console.ReadKey();
            ClienteVenda.VendasCli();
        }

        public static bool ValidarLogin(string CPF, string senha)
        {
            string stringDeConexao = @"Data Source=DESKTOP-HUTS0O2;Initial Catalog=BD_FAZENDA;Integrated Security=True;";
            using (SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                string consulta = "SELECT COUNT(*) FROM Cliente WHERE CPF = @CPF AND Senha = @Senha";

                using (SqlCommand comando = new SqlCommand(consulta, conexao))
                {
                    comando.Parameters.AddWithValue("@CPF", CPF);
                    comando.Parameters.AddWithValue("@Senha", senha);

                    conexao.Open();
                    int resultado = (int)comando.ExecuteScalar();

                    // Se o resultado for maior que 0, significa que o login é válido
                    return resultado > 0;
                }
            }
        }
    }
}
