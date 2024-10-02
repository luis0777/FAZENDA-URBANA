using PRINCIPAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente;

namespace ClienteCad
{
    public class ClienteCadastro
    {

        public static void ClienteCad()
        {

            string NomeCliente = "";
            string CPF = "";
            string email = "";
            string senha = "";

            Console.WriteLine("Faça seu cadastro inserindo as informações necessárias:");

            while (string.IsNullOrWhiteSpace(NomeCliente))
            {
                Console.Write("Nome: ");
                NomeCliente = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(NomeCliente))
                {
                    Console.WriteLine("O campo Nome é obrigatório. Por favor, preencha-o.");
                }
            }

            while (string.IsNullOrWhiteSpace(CPF))
            {
                Console.Write("CPF: ");
                CPF = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(CPF))
                {
                    Console.WriteLine("O campo CPF é obrigatório. Por favor, preencha-o.");
                }
            }

            while (string.IsNullOrWhiteSpace(email))
            {
                Console.Write("Email: ");
                email = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(email))
                {
                    Console.WriteLine("O campo Email é obrigatório. Por favor, preencha-o.");
                }
            }

            while (string.IsNullOrWhiteSpace(senha))
            {
                Console.Write("Senha de 4 dígitos: ");
                senha = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(senha))
                {
                    Console.WriteLine("O campo Senha é obrigatório. Por favor, preencha-o.");
                }
                else if (senha.Length != 4)
                {
                    Console.WriteLine("A senha deve ter exatamente 4 dígitos. Por favor, insira novamente.");
                    senha = "";
                }
            }

            InserirCliente(NomeCliente, CPF, email, senha);
        }

        static void InserirCliente(string NomeCliente, string CPF, string email, string senha)
        {
            string stringDeConexao = @"Data Source=DESKTOP-HUTS0O2;Initial Catalog=BD_FAZENDA;Integrated Security=True;";


            string consulta = "INSERT INTO [dbo].[Cliente] (NomeCliente, CPF, Email, Senha) VALUES (@NomeCliente, @CPF, @email, @senha)";

            using (SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexao))
                {
                    comando.Parameters.AddWithValue("@NomeCliente", NomeCliente);
                    comando.Parameters.AddWithValue("@CPF", CPF);
                    comando.Parameters.AddWithValue("@email", email);
                    comando.Parameters.AddWithValue("@senha", senha);

                    conexao.Open();
                    int resultado = comando.ExecuteNonQuery();
                    Console.WriteLine("Você foi cadastrado com sucesso");

                    Console.WriteLine("Clique em qualquer tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    ClienteLogin.Cliente();

                }
            }
        }
    }

}
