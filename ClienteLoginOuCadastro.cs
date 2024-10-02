using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClienteCad;
using FazerLogin;

namespace Cliente
{
    public class ClienteLogin
    {
        public static void Cliente()
        {
            bool opcaoValida = false;

            while (!opcaoValida)
            {
                Console.WriteLine("Escolha uma das opções:\n1 - Fazer cadastro\n2 - Fazer login");
                char escolha;
                escolha = char.Parse(Console.ReadLine());
                Console.WriteLine(); // Adiciona uma nova linha para separar a entrada do usuário

                switch (escolha)
                {
                    case '1':
                        ClienteCadastro.ClienteCad();
                        opcaoValida = true;
                        break;

                    case '2':
                        ClienteFazerLogin.FazerLogin();
                        opcaoValida = true;
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha 1 ou 2.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
