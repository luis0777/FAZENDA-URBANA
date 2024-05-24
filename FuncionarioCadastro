using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionarioCad
{
    public class FuncionarioCadastro
    {
        public static void FuncionarioCad()
        {
            string NomeFuncionario = "";
            string CPF = "";
            string funcao = "";

            Console.WriteLine("Faça o cadastro de um novo funcionário:");

            while (string.IsNullOrWhiteSpace(NomeFuncionario))
            {
                Console.Write("Nome: ");
                NomeFuncionario = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(NomeFuncionario))
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

            while (string.IsNullOrWhiteSpace(funcao))
            {
                Console.Write("Função: ");
                funcao = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(funcao))
                {
                    Console.WriteLine("O campo Função é obrigatório. Por favor, preencha-o.");
                }
            }

            InserirFuncionario(NomeFuncionario, CPF, funcao);
        }

        public static void InserirFuncionario(string NomeFuncionario, string CPF, string funcao )
        {
            string stringDeConexao = @"Data Source=DESKTOP-HUTS0O2;Initial Catalog=BD_FAZENDA;Integrated Security=True;";

            string consulta = "INSERT INTO Funcionario (NomeFuncionario, CPF, Funcao) VALUES (@NomeFuncionario, @CPF, @funcao)";

            using (SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexao))
                {
                    comando.Parameters.AddWithValue("@NomeFuncionario", NomeFuncionario);
                    comando.Parameters.AddWithValue("@CPF", CPF);
                    comando.Parameters.AddWithValue("@funcao", funcao);

                    conexao.Open();
                    int resultado = comando.ExecuteNonQuery();
                    Console.WriteLine("Funcionário cadastrado com sucesso");
                }
            }
        }
        public static void MostrarFuncionario()
        {
            string stringDeConexao = @"Data Source=DESKTOP-HUTS0O2;Initial Catalog=BD_FAZENDA;Integrated Security=True;";

            string consulta = "SELECT NomeFuncionario, CPF, Funcao FROM Funcionario";

            using (SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexao))
                {
                    conexao.Open();
                    using (SqlDataReader leitor = comando.ExecuteReader())
                    {
                        Console.WriteLine("Funcionários cadastrados:\n");

                        while (leitor.Read())
                        {
                            string nome = leitor["NomeFuncionario"].ToString();
                            string CPF = leitor["CPF"].ToString();
                            string funcao = leitor["funcao"].ToString();

                            Console.WriteLine($"Nome: {nome}, CPF: {CPF}, Funcao: {funcao}");
                            Console.ReadKey();
                        }
                    }
                }
            }

        }
        public static void RemoverFuncionario()
        {
            Console.WriteLine("Digite o ID do funcionário que deseja remover:");
            int idFuncionario = int.Parse(Console.ReadLine());

            if (RemoverFuncionario(idFuncionario))
            {
                Console.WriteLine("Funcionário removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Não foi possível remover o funcionário. Verifique se o ID está correto.");
            }
        }

        public static bool RemoverFuncionario(int idFuncionario)
        {
            string stringDeConexao = @"Data Source=DESKTOP-HUTS0O2;Initial Catalog=BD_FAZENDA;Integrated Security=True;";

            string consulta = "DELETE FROM Funcionario WHERE ID = @ID";

            using (SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexao))
                {
                    comando.Parameters.AddWithValue("@ID", idFuncionario);

                    conexao.Open();
                    int linhasAfetadas = comando.ExecuteNonQuery();

                    // Se pelo menos uma linha foi afetada, significa que o funcionário foi removido
                    return linhasAfetadas > 0;
                }
            }
        }

        public static void AlterarFuncaoFuncionario()
        {
            Console.Clear();
            int idFuncionario = 0;
            string novaFuncao = "";

            while (idFuncionario <= 0)
            {
                Console.WriteLine("Digite o ID do funcionário que deseja alterar a função:");
                string idInput = Console.ReadLine();

                if (!int.TryParse(idInput, out idFuncionario) || idFuncionario <= 0)
                {
                    Console.WriteLine("ID inválido. Por favor, digite um número positivo.");
                    idFuncionario = 0;
                }
            }

            while (string.IsNullOrWhiteSpace(novaFuncao))
            {
                Console.WriteLine("Digite a nova função do funcionário:");
                novaFuncao = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(novaFuncao))
                {
                    Console.WriteLine("O campo Função é obrigatório. Por favor, preencha-o.");
                }
            }

            if (AlterarFuncaoFuncionarioBD(idFuncionario, novaFuncao))
            {
                Console.WriteLine("Função do funcionário alterada com sucesso!");
            }
            else
            {
                Console.WriteLine("Não foi possível alterar a função do funcionário. Verifique se o ID está correto.");
            }
        }
        public static bool AlterarFuncaoFuncionarioBD(int idFuncionario, string novaFuncao)
        {
            string stringDeConexao = @"Data Source=DESKTOP-HUTS0O2;Initial Catalog=BD_FAZENDA;Integrated Security=True;";

            string consulta = "UPDATE Funcionario SET Funcao = @novaFuncao WHERE ID = @ID";

            using (SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexao))
                {
                    comando.Parameters.AddWithValue("@ID", idFuncionario);
                    comando.Parameters.AddWithValue("@novaFuncao", novaFuncao);

                    conexao.Open();
                    int linhasAfetadas = comando.ExecuteNonQuery();

                    // Se pelo menos uma linha foi afetada, significa que a função do funcionário foi alterada
                    return linhasAfetadas > 0;
                }
            }
        }
    }
}
