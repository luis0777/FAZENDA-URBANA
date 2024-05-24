using System;
using System.Data.SqlClient;

namespace VendasCli
{
    public class ClienteVenda
    {
        public static void VendasCli()
        {
            bool continuarComprando = true;

            while (continuarComprando)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Lista de Produtos Disponíveis para Venda:");
                    Console.WriteLine("----------------------------------------");

                    // Consultar o banco de dados de produtos
                    string stringDeConexao = @"Data Source=DESKTOP-HUTS0O2;Initial Catalog=BD_FAZENDA;Integrated Security=True;";
                    string consulta = "SELECT Id, produto, quantidade, preco FROM Produtos";

                    using (SqlConnection conexao = new SqlConnection(stringDeConexao))
                    {
                        using (SqlCommand comando = new SqlCommand(consulta, conexao))
                        {
                            conexao.Open();
                            using (SqlDataReader reader = comando.ExecuteReader())
                            {
                                // Exibir os produtos disponíveis
                                while (reader.Read())
                                {
                                    int idProduto = Convert.ToInt32(reader["Id"]);
                                    string nomeProduto = Convert.ToString(reader["produto"]);
                                    int quantidadeProduto = Convert.ToInt32(reader["quantidade"]);
                                    double precoProduto = Convert.ToDouble(reader["preco"]);

                                    Console.WriteLine($"ID: {idProduto} | Produto: {nomeProduto} | Quantidade disponível: {quantidadeProduto} kg | Preço por kg: R${precoProduto}");
                                }
                            }
                        }
                    }

                    // Permitir ao usuário escolher o produto e a quantidade
                    Console.WriteLine("\nDigite o ID do produto que deseja comprar:");
                    int idEscolhido;
                    while (!int.TryParse(Console.ReadLine(), out idEscolhido))
                    {
                        Console.WriteLine("Por favor, digite um ID válido.");
                        Console.WriteLine("\nDigite o ID do produto que deseja comprar:");
                    }

                    Console.WriteLine("Digite a quantidade em kg que deseja comprar:");
                    double quantidadeEscolhida;
                    while (!double.TryParse(Console.ReadLine(), out quantidadeEscolhida) || quantidadeEscolhida <= 0)
                    {
                        Console.WriteLine("Por favor, digite uma quantidade válida (maior que zero).");
                        Console.WriteLine("\nDigite a quantidade em kg que deseja comprar:");
                    }

                    // Escolher o método de pagamento
                    Console.WriteLine("\nEscolha o método de pagamento:");
                    Console.WriteLine("1 - Crédito");
                    Console.WriteLine("2 - Débito");
                    Console.WriteLine("3 - Pix");

                    int metodoPagamento;
                    while (!int.TryParse(Console.ReadLine(), out metodoPagamento) || (metodoPagamento != 1 && metodoPagamento != 2 && metodoPagamento != 3))
                    {
                        Console.WriteLine("Por favor, digite uma opção válida (1, 2 ou 3).");
                        Console.WriteLine("\nEscolha o método de pagamento:");
                        Console.WriteLine("1 - Crédito");
                        Console.WriteLine("2 - Débito");
                        Console.WriteLine("3 - Pix");
                    }

                    // Processar a venda
                    ProcessarVenda(idEscolhido, quantidadeEscolhida, metodoPagamento);

                    // Perguntar se o usuário deseja comprar novamente
                    Console.WriteLine("\nDeseja comprar novamente? (S/N)");
                    string resposta = Console.ReadLine();
                    continuarComprando = (resposta.ToLower() == "s");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                }
            }
        }

        public static void ProcessarVenda(int idProduto, double quantidadeVendida, int metodoPagamento)
        {
            try
            {
                // Consultar o banco de dados para obter informações do produto escolhido
                string stringDeConexao = @"Data Source=DESKTOP-HUTS0O2;Initial Catalog=BD_FAZENDA;Integrated Security=True;";
                string consultaProduto = "SELECT produto, quantidade, preco FROM Produtos WHERE Id = @ID";

                using (SqlConnection conexaoConsulta = new SqlConnection(stringDeConexao))
                {
                    using (SqlCommand comandoConsulta = new SqlCommand(consultaProduto, conexaoConsulta))
                    {
                        comandoConsulta.Parameters.AddWithValue("@ID", idProduto);

                        conexaoConsulta.Open();
                        using (SqlDataReader reader = comandoConsulta.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string Produto = Convert.ToString(reader["produto"]);
                                double Quantidade = Convert.ToDouble(reader["quantidade"]);
                                double Preco = Convert.ToDouble(reader["preco"]);

                                if (quantidadeVendida <= Quantidade)
                                {
                                    double valorTotal = quantidadeVendida * Preco;

                                    // Atualizar a quantidade do produto no banco de dados
                                    string atualizarQuantidade = "UPDATE Produtos SET quantidade = quantidade - @Quantidade WHERE Id = @ID";

                                    using (SqlConnection conexaoAtualizacao = new SqlConnection(stringDeConexao))
                                    {
                                        using (SqlCommand comandoAtualizar = new SqlCommand(atualizarQuantidade, conexaoAtualizacao))
                                        {
                                            comandoAtualizar.Parameters.AddWithValue("@Quantidade", quantidadeVendida);
                                            comandoAtualizar.Parameters.AddWithValue("@ID", idProduto);

                                            conexaoAtualizacao.Open();
                                            int linhasAfetadas = comandoAtualizar.ExecuteNonQuery();

                                            if (linhasAfetadas > 0)
                                            {
                                                RegistrarVenda(Produto, quantidadeVendida, valorTotal, metodoPagamento); // Corrigido para passar quantidadeVendida e valorTotal
                                            }
                                            else
                                            {
                                                Console.WriteLine("Erro ao processar a venda.");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Quantidade insuficiente em estoque.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Produto não encontrado.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }

        public static void RegistrarVenda(string Produto, double QuantidadeVendida, double ValorTotal, int FormaDePagamento)
        {
            try
            {
                // Consultar o banco de dados para obter informações do produto escolhido
                string stringDeConexao = @"Data Source=DESKTOP-HUTS0O2;Initial Catalog=BD_FAZENDA;Integrated Security=True;";

                // Inserir a venda no banco de dados
                string inserirVenda = "INSERT INTO Vendas (Produto, QuantidadeVendida, ValorTotal, FormaDePagamento) VALUES (@Produto, @QuantidadeVendida, @ValorTotal, @FormaDePagamento)";

                using (SqlConnection conexaoInserirVenda = new SqlConnection(stringDeConexao))
                {
                    using (SqlCommand comandoInserirVenda = new SqlCommand(inserirVenda, conexaoInserirVenda))
                    {
                        comandoInserirVenda.Parameters.AddWithValue("@Produto", Produto);
                        comandoInserirVenda.Parameters.AddWithValue("@QuantidadeVendida", QuantidadeVendida); // Ajustado para Quantidade
                        comandoInserirVenda.Parameters.AddWithValue("@ValorTotal", ValorTotal); // Ajustado para Preco
                        comandoInserirVenda.Parameters.AddWithValue("@FormaDePagamento", FormaDePagamento);

                        conexaoInserirVenda.Open();
                        int linhasAfetadas = comandoInserirVenda.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            Console.WriteLine("Venda registrada com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Erro ao registrar a venda.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }


        public static void MostrarVendas()
        {
            try
            {
                // Conexão com o banco de dados
                string stringDeConexao = @"Data Source=DESKTOP-HUTS0O2;Initial Catalog=BD_FAZENDA;Integrated Security=True;";
                string consultaVendas = "SELECT * FROM Vendas";

                using (SqlConnection conexao = new SqlConnection(stringDeConexao))
                {
                    using (SqlCommand comando = new SqlCommand(consultaVendas, conexao))
                    {
                        conexao.Open();
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            Console.WriteLine("Vendas realizadas:");
                            Console.WriteLine("--------------------------------------------");
                            while (reader.Read())
                            {
                                int idVenda = Convert.ToInt32(reader["ID"]); // Corrigido para "ID" (letras maiúsculas)
                                string produto = Convert.ToString(reader["Produto"]);
                                double QuantidadeVendida = Convert.ToDouble(reader["QuantidadeVendida"]); // Corrigido para "QuantidadeVendida"
                                double valorTotal = Convert.ToDouble(reader["ValorTotal"]); // Corrigido para "ValorTotal"
                                int FormaDePagamento = Convert.ToInt32(reader["FormaDePagamento"]);

                                string metodoPagamentoStr = "";
                                if (FormaDePagamento == 1)
                                {
                                    metodoPagamentoStr = "Crédito";
                                }
                                else if (FormaDePagamento == 2)
                                {
                                    metodoPagamentoStr = "Débito";
                                }
                                else if (FormaDePagamento == 3)
                                {
                                    metodoPagamentoStr = "Pix";
                                }

                                Console.WriteLine($"ID: {idVenda} | Produto: {produto} | Quantidade Vendida: {QuantidadeVendida} | Valor Total: R${valorTotal} | Método de Pagamento: {metodoPagamentoStr}");
                            }
                            Console.WriteLine("--------------------------------------------");
                            Console.ReadKey();
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
