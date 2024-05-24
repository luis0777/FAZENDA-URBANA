using System;
using System.Threading;
using adm;
using Cliente;


namespace PRINCIPAL
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.ReadKey();
                Console.WriteLine("$$$$$$$$\\  $$$$$$\\  $$$$$$$$\\ $$$$$$$$\\ $$\\   $$\\ $$$$$$$\\   $$$$$$\\        $$\\   $$\\ $$$$$$$\\  $$$$$$$\\   $$$$$$\\  $$\\   $$\\  $$$$$$\\");
                Thread.Sleep(500);
                Console.WriteLine("$$  _____|$$  __$$\\ \\____$$  |$$  _____|$$$\\  $$ |$$  __$$\\ $$  __$$\\       $$ |  $$ |$$  __$$\\ $$  __$$\\ $$  __$$\\ $$$\\  $$ |$$  __$$\\ ");
                Thread.Sleep(500);
                Console.WriteLine("$$ |      $$ /  $$ |    $$  / $$ |      $$$$\\ $$ |$$ |  $$ |$$ /  $$ |      $$ |  $$ |$$ |  $$ |$$ |  $$ |$$ /  $$ |$$$$\\ $$ |$$ /  $$ |");
                Thread.Sleep(500);
                Console.WriteLine("$$$$$\\    $$$$$$$$ |   $$  /  $$$$$\\    $$ $$\\$$ |$$ |  $$ |$$$$$$$$ |      $$ |  $$ |$$$$$$$  |$$$$$$$\\ |$$$$$$$$ |$$ $$\\$$ |$$$$$$$$ | ");
                Thread.Sleep(500);
                Console.WriteLine("$$  __|   $$  __$$ |  $$  /   $$  __|   $$ \\$$$$ |$$ |  $$ |$$  __$$ |      $$ |  $$ |$$  __$$< $$  __$$\\ $$  __$$ |$$ \\$$$$ |$$  __$$ |");
                Thread.Sleep(500);
                Console.WriteLine("$$ |      $$ |  $$ | $$  /    $$ |      $$ |\\$$$ |$$ |  $$ |$$ |  $$ |      $$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |\\$$$ |$$ |  $$ |");
                Thread.Sleep(500);
                Console.WriteLine("$$ |      $$ |  $$ |$$$$$$$$\\ $$$$$$$$\\ $$ | \\$$ |$$$$$$$  |$$ |  $$ |      \\$$$$$$  |$$ |  $$ |$$$$$$$  |$$ |  $$ |$$ | \\$$ |$$ |  $$ |");
                Thread.Sleep(500);
                Console.WriteLine("\\__|      \\__|  \\__|\\________|\\________|\\__|  \\__|\\_______/ \\__|  \\__|       \\______/ \\__|  \\__|\\_______/ \\__|  \\__|\\__|  \\__|\\__|  \\__|");
                Thread.Sleep(500);

                Console.Write("AS PITAYAS DA NOSSA FAZENDA URBANA SÃO CULTIVADAS COM MUITO CUIDADO PARA GARANTIR A MÁXIMA QUALIDADE.\n\n");

                Console.WriteLine("Olá! Seja bem-vindo ao sistema de vendas e gerenciamento da Fazenda Urbana\nEscolha sua forma de login:");

                bool loginValido = false;

                while (!loginValido)
                {
                    Console.WriteLine("1 - CLIENTE\n2 - ADMINISTRADOR\n3 - SAIR");
                    char usuario = char.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (usuario)
                    {
                        case '1':
                            ClienteLogin.Cliente();
                            loginValido = true;
                            break;

                        case '2':
                            AdmLogin.Admin();
                            Admlogado.Admin1();
                            loginValido = true;
                            break;

                        case '3':
                            Console.Write("O programa será encerrado em 3");
                            Thread.Sleep(500);
                            Console.Write(",2");
                            Thread.Sleep(500);
                            Console.Write(",1");
                            Thread.Sleep(500);
                            return; 

                        default:
                            Console.WriteLine("Opção de login inválida. Clique ENTER para tentar novamente.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
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
