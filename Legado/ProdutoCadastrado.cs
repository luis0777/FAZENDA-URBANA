using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostraProduto
{
    public class ProdutoCadastrado
    {
        public static void MostrarProduto()
        {
            string stringDeConexao = @"Data Source=DESKTOP-HUTS0O2;Initial Catalog=BD_FAZENDA;Integrated Security=True;";

            string consulta = "SELECT * FROM Produtos"; // Consulta SQL para selecionar todos os clientes

            using (SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexao))
                {
                    conexao.Open();
                    using (SqlDataReader leitor = comando.ExecuteReader())
                    {
                        Console.Clear();
                        Console.WriteLine("\nProdutos cadastrados:\n");
                        while (leitor.Read())
                        {
                            Console.WriteLine($"ID: {leitor["ID"]}, Produto: {leitor["Produto"]}, Quantidade: {leitor["Quantidade"]}, Preco: {leitor["Preco"]}");
                        }
                        Console.ReadKey();
                    }
                }
            }
        }

        public static void AlterarProduto()
        {
            try
            {
                Console.WriteLine("\nDigite o ID do produto que deseja alterar: ");
                int idProduto;
                while (!int.TryParse(Console.ReadLine(), out idProduto))
                {
                    Console.WriteLine("Por favor, digite um ID válido.");
                    Console.WriteLine("\nDigite o ID do produto que deseja alterar: ");
                }

                Console.WriteLine("Digite as novas informações (deixe em branco para manter a mesma informação):");


                Console.Write("Quantidade: ");
                int novaQuantidade;
                int.TryParse(Console.ReadLine(), out novaQuantidade); // Permite deixar em branco

                Console.Write("Preço: ");
                double novoPreco;
                double.TryParse(Console.ReadLine(), out novoPreco); // Permite deixar em branco

                Console.WriteLine("Escolha a operação que deseja realizar com a quantidade:");
                Console.WriteLine("1 - Adicionar");
                Console.WriteLine("2 - Remover");

                int operacao;
                while (!int.TryParse(Console.ReadLine(), out operacao) || (operacao != 1 && operacao != 2))
                {
                    Console.WriteLine("Por favor, digite uma opção válida (1 ou 2).");
                    Console.WriteLine("Escolha a operação que deseja realizar com a quantidade:");
                    Console.WriteLine("1 - Adicionar");
                    Console.WriteLine("2 - Remover");
                }

                string stringDeConexao = @"Data Source=DESKTOP-HUTS0O2;Initial Catalog=BD_FAZENDA;Integrated Security=True;";

                string consulta = "UPDATE Produtos SET ";

                // Adiciona os parâmetros e as partes relevantes da consulta SQL conforme necessário
                if (novaQuantidade != 0)
                {
                    if (operacao == 1)
                    {
                        consulta += "quantidade = quantidade + @Quantidade, ";
                    }
                    else if (operacao == 2)
                    {
                        consulta += "quantidade = quantidade - @Quantidade, ";
                    }
                }
                if (novoPreco != 0.0)
                {
                    consulta += "preco = @Preco, ";
                }

                // Remove a vírgula extra do final da consulta
                consulta = consulta.TrimEnd(' ', ',');

                // Adiciona a condição WHERE
                consulta += " WHERE Id = @ID";

                using (SqlConnection conexao = new SqlConnection(stringDeConexao))
                {
                    using (SqlCommand comando = new SqlCommand(consulta, conexao))
                    {

                        if (novaQuantidade != 0)
                        {
                            comando.Parameters.AddWithValue("@Quantidade", Math.Abs(novaQuantidade)); // Garante que a quantidade seja positiva
                        }
                        if (novoPreco != 0.0)
                        {
                            comando.Parameters.AddWithValue("@Preco", novoPreco);
                        }

                        comando.Parameters.AddWithValue("@ID", idProduto);

                        conexao.Open();
                        int linhasAfetadas = comando.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            if (operacao == 1)
                            {
                                Console.WriteLine($"Foram adicionadas {novaQuantidade} unidades do produto ao estoque.");
                            }
                            else if (operacao == 2)
                            {
                                Console.WriteLine($"Foram removidas {Math.Abs(novaQuantidade)} unidades do produto do estoque.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nenhum produto foi encontrado com o ID fornecido.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}

