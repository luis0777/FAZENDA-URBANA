using System;
using System.Data.SqlClient;

namespace FornecedorCad
{
    public class FornecedorCadastro
    {
        public static void FornecedorCad()
        {
            string nomeEmpresa = "";
            string CNPJ = "";

            Console.WriteLine("Faça o cadastro inserindo as informações necessárias:");

            while (string.IsNullOrWhiteSpace(nomeEmpresa))
            {
                Console.Write("Empresa: ");
                nomeEmpresa = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nomeEmpresa))
                {
                    Console.WriteLine("O campo Empresa é obrigatório. Por favor, preencha-o.");
                }
            }

            while (string.IsNullOrWhiteSpace(CNPJ))
            {
                Console.Write("CNPJ: ");
                CNPJ = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(CNPJ))
                {
                    Console.WriteLine("O campo CNPJ é obrigatório. Por favor, preencha-o.");
                }
            }

            string adubo;
            while (true)
            {
                Console.Write("Escolha o tipo de adubo\n1 - NPK (nitrogênio, fósforo e potássio) 2 - Esterco de animal 3 - Foliar rico em micronutrientes: ");
                string escolhaAdubo = Console.ReadLine();

                switch (escolhaAdubo)
                {
                    case "1":
                        adubo = "NPK (nitrogênio, fósforo e potássio)";
                        break;
                    case "2":
                        adubo = "Esterco de animal ";
                        break;
                    case "3":
                        adubo = "Foliar rico em micronutrientes ";
                        break;
                    default:
                        Console.WriteLine("Escolha inválida. Por favor, tente novamente.");
                        continue; // Voltar ao início do loop
                }
                break; // Sair do loop se a escolha for válida
            }

            string quantidadeAdubo = "";
            while (string.IsNullOrWhiteSpace(quantidadeAdubo))
            {
                Console.Write("Quantidade de adubo em KG: ");
                quantidadeAdubo = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(quantidadeAdubo))
                {
                    Console.WriteLine("O campo Quantidade de adubo é obrigatório. Por favor, preencha-o.");
                }
                else if (!int.TryParse(quantidadeAdubo, out int quantidade) || quantidade <= 0)
                {
                    Console.WriteLine("Por favor, insira um valor numérico válido e maior que zero.");
                    quantidadeAdubo = "";
                }
            }

            string agrotoxico;
            while (true)
            {
                Console.Write("Escolha o tipo de agrotoxico\n1 - Fungicidas 2 - Inseticidas 3 - Herbicidas: ");
                string escolhaAgrotoxico = Console.ReadLine();

                switch (escolhaAgrotoxico)
                {
                    case "1":
                        agrotoxico = "Fungicidas";
                        break;
                    case "2":
                        agrotoxico = "Inseticidas ";
                        break;
                    case "3":
                        agrotoxico = "Herbicidas ";
                        break;
                    default:
                        Console.WriteLine("Escolha inválida. Por favor, tente novamente.");
                        continue; // Voltar ao início do loop
                }
                break; // Sair do loop se a escolha for válida
            }

            string quantidadeAgrotoxico = "";
            while (string.IsNullOrWhiteSpace(quantidadeAgrotoxico))
            {
                Console.Write("Quantidade de agrotóxico em KG: ");
                quantidadeAgrotoxico = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(quantidadeAgrotoxico))
                {
                    Console.WriteLine("O campo Quantidade de agrotóxico é obrigatório. Por favor, preencha-o.");
                }
                else if (!int.TryParse(quantidadeAgrotoxico, out int quantidade) || quantidade <= 0)
                {
                    Console.WriteLine("Por favor, insira um valor numérico válido e maior que zero.");
                    quantidadeAgrotoxico = "";
                }
            }

            string Muda;
            while (true)
            {
                Console.Write("Escolha o tipo da muda\n1 - Vermelha 2 - Amarela 3 - Branca: ");
                string escolhaMuda = Console.ReadLine();

                switch (escolhaMuda)
                {
                    case "1":
                        Muda = "Vermelha";
                        break;
                    case "2":
                        Muda = "Amarela";
                        break;
                    case "3":
                        Muda = "Vermelha";
                        break;
                    default:
                        Console.WriteLine("Escolha inválida. Por favor, tente novamente.");
                        continue; // Voltar ao início do loop
                }
                break; // Sair do loop se a escolha for válida
            }

            string quantidadeMuda = "";
            while (string.IsNullOrWhiteSpace(quantidadeMuda))
            {
                Console.Write("Quantidade de mudas (unidade): ");
                quantidadeMuda = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(quantidadeMuda))
                {
                    Console.WriteLine("O campo Quantidade de mudas é obrigatório. Por favor, preencha-o.");
                }
                else if (!int.TryParse(quantidadeMuda, out int quantidade) || quantidade <= 0)
                {
                    Console.WriteLine("Por favor, insira um valor numérico válido e maior que zero.");
                    quantidadeMuda = "";
                }
            }

            InserirFornecedor(nomeEmpresa, CNPJ, adubo, quantidadeAdubo, agrotoxico, quantidadeAgrotoxico, Muda, quantidadeMuda);
        }

        static void InserirFornecedor(string nomeEmpresa, string CNPJ, string adubo, string quantidadeAdubo, string agrotoxico, string quantidadeAgrotoxico, string Muda, string quantidadeMuda)
        {
            string stringDeConexao = @"Data Source=DESKTOP-HUTS0O2;Initial Catalog=BD_FAZENDA;Integrated Security=True;";

            string consulta = "INSERT INTO Fornecedor (nomeEmpresa, CNPJ, adubo, quantidadeAdubo, agrotoxico, quantidadeAgrotoxico, Muda, quantidadeMuda) VALUES (@nomeEmpresa, @CNPJ, @adubo, @quantidadeAdubo, @agrotoxico, @quantidadeAgrotoxico, @Muda, @quantidadeMuda)";

            try
            {
                using (SqlConnection conexao = new SqlConnection(stringDeConexao))
                {
                    using (SqlCommand comando = new SqlCommand(consulta, conexao))
                    {
                        comando.Parameters.AddWithValue("@nomeEmpresa", nomeEmpresa);
                        comando.Parameters.AddWithValue("@CNPJ", CNPJ);
                        comando.Parameters.AddWithValue("@adubo", adubo);
                        comando.Parameters.AddWithValue("@quantidadeAdubo", quantidadeAdubo);
                        comando.Parameters.AddWithValue("@agrotoxico", agrotoxico);
                        comando.Parameters.AddWithValue("@quantidadeAgrotoxico", quantidadeAgrotoxico);
                        comando.Parameters.AddWithValue("@Muda", Muda);
                        comando.Parameters.AddWithValue("@quantidadeMuda", quantidadeMuda);

                        conexao.Open();
                        int resultado = comando.ExecuteNonQuery();
                        Console.WriteLine("Fornecedor cadastrado com sucesso. Registros afetados: " + resultado);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir fornecedor: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}
