using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostrarMateriaPrima
{
    public class MateriaPrima
    {
        public static void MostrarMateriaPrima()
        {
            string stringDeConexao = @"Data Source=DESKTOP-HUTS0O2;Initial Catalog=BD_FAZENDA;Integrated Security=True;";

            string consulta = "SELECT * FROM Fornecedor";

            using (SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexao))
                {
                    conexao.Open();
                    using (SqlDataReader leitor = comando.ExecuteReader())
                    {
                        Console.Clear();
                        Console.WriteLine("\nMateria Prima fornecida:\n");
                        while (leitor.Read())
                        {
                            Console.WriteLine($"\nID: {leitor["ID"]}\nEMPRESA: {leitor["NomeEmpresa"]} - CNPJ: {leitor["CNPJ"]}\nADUBO: {leitor["adubo"]} - QUANTIDADE: {leitor["QuantidadeAdubo"]}\nAGROTOXICO: {leitor["Agrotoxico"]} - QUANTIDADE: {leitor["QuantidadeAgrotoxico"]}\nMUDA: {leitor["muda"]} - QUANTIDADE: {leitor["QuantidadeMuda"]}");
                        }
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}

