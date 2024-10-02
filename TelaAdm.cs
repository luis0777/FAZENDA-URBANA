using System;
using System.Threading;
using MostrarClientes;
using FuncionarioCad;
using FornecedorCad;
using MostraProduto;
using MostrarMateriaPrima;
using VendasCli;
using RemoverFornecedor;
using PRINCIPAL;

namespace adm
{
    public class AdmLogin
    {
        public static void Admin()
        {
            bool loginSucesso = false;

            // Loop até o login ser bem-sucedido
            while (!loginSucesso)
            {
                Console.WriteLine("Inserir as informações corretas para realizar o login");

                // Solicitar informações de login
                Console.Write("Usuário: ");
                string usuario = Console.ReadLine();
                Console.Write("Senha: ");
                string senha = Console.ReadLine();

                // Verificar se as credenciais estão corretas
                if (usuario == "admin" && senha == "5891")
                {
                    Console.WriteLine("Aguarde...");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine("Login bem-sucedido! Você está autorizado a acessar.\nClique ENTER para continuar.");
                    Console.ReadKey();
                    loginSucesso = true; // Define a variável para sair do loop
                }
                else
                {
                    Console.WriteLine("Aguarde...");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine("As informações de login estão incorretas. Clique ENTER para tentar novamente.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
        }
    }

    public class Admlogado
    {
        public static void Admin1()
        {
            Console.Clear();
            Console.WriteLine("Seja bem vindo Administrador, aqui você fará toda gestão da sua fazenda!!!");
            bool continua = true;

            while (continua)
            {
                Console.WriteLine("1 - SEÇÃO CLIENTES\n2 - SEÇÃO FUNCIONARIOS\n3 - SEÇAO FORNECEDORES\n4 - SEÇÃO PRODUTOS\n5 - SEÇÃO MATERIA PRIMA\n6 - SEÇÃO VENDAS");
                char escolha = char.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Escolha qual ação deseja fazer\n1 - VER CLIENTES CADASTRADOS");
                        char escolha1;
                        bool escolha1Valida = char.TryParse(Console.ReadLine(), out escolha1);

                        while (!escolha1Valida || (escolha1 != '1' && escolha1 != '2' && escolha1 != '3'))
                        {
                            Console.WriteLine("Opção inválida. Por favor, escolha novamente.");
                            escolha1Valida = char.TryParse(Console.ReadLine(), out escolha1);
                        }

                        switch (escolha1)
                        {
                            case '1':
                                Console.Clear();
                                ClienteCadastrado.MostrarClientes();
                                break;
                        }
                        break;

                    case '2':
                        Console.Clear();
                        Console.WriteLine("Escolha qual ação deseja fazer\n1 - CADASTRAR NOVO FUNCIONARIO\n2 - VER FUNCIONARIOS CADASTRADOS\n3 - ALTERAR INFORMAÇÃO DO FUNCIONARIO\n4 - REMOVER UM FUNCIONARIO");
                        char escolha2;
                        bool escolha2Valida = char.TryParse(Console.ReadLine(), out escolha2);

                        while (!escolha2Valida || (escolha2 != '1' && escolha2 != '2' && escolha2 != '3' && escolha2 != '4'))
                        {
                            Console.WriteLine("Opção inválida. Por favor, escolha novamente.");
                            escolha2Valida = char.TryParse(Console.ReadLine(), out escolha2);
                        }

                        switch (escolha2)
                        {
                            case '1':
                                FuncionarioCadastro.FuncionarioCad();
                                break;

                            case '2':
                                Console.Clear();
                                FuncionarioCadastro.MostrarFuncionario();
                                break;

                            case '3':
                                FuncionarioCadastro.AlterarFuncaoFuncionario();
                                break;

                            case '4':
                                Console.Clear();
                                FuncionarioCadastro.RemoverFuncionario();
                                break;
                        }
                        break;

                    case '3':
                        Console.Clear();
                        Console.WriteLine("Escolha qual ação deseja fazer\n1 - CADASTRAR NOVO FORNECEDOR\n2 - REMOVER UM FORNECEDOR");
                        char escolha3;
                        bool escolha3Valida = char.TryParse(Console.ReadLine(), out escolha3);

                        while (!escolha3Valida || (escolha3 != '1' && escolha3 != '2'))
                        {
                            Console.WriteLine("Opção inválida. Por favor, escolha novamente.");
                            escolha3Valida = char.TryParse(Console.ReadLine(), out escolha3);
                        }

                        switch (escolha3)
                        {
                            case '1':
                                Console.Clear();
                                FornecedorCadastro.FornecedorCad();
                                break;


                            case '2':
                                Console.Clear();
                                ExcluirFornecedor.RemoverFornecedor();
                                break;
                        }
                        break;

                    case '4':
                        Console.Clear();
                        Console.WriteLine("Escolha qual ação deseja fazer\n1 - VER PRODUTOS CADASTRADOS\n2 - ALTERAR INFORMAÇÕES DO PRODUTO");
                        char escolha4;
                        bool escolha4Valida = char.TryParse(Console.ReadLine(), out escolha4);

                        while (!escolha4Valida || (escolha4 != '1' && escolha4 != '2' ))
                        {
                            Console.WriteLine("Opção inválida. Por favor, escolha novamente.");
                            escolha4Valida = char.TryParse(Console.ReadLine(), out escolha4);
                        }

                        switch (escolha4)
                        {

                            case '1':
                                ProdutoCadastrado.MostrarProduto();
                                break;

                            case '2':
                                ProdutoCadastrado.AlterarProduto();
                                break;
                        }
                        break;

                    case '5':
                        MateriaPrima.MostrarMateriaPrima();
                        break;

                    case '6':
                        Console.Clear();
                        ClienteVenda.MostrarVendas();
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha novamente.");
                        break;
                }

                Console.WriteLine("Deseja realizar outra operação? (S/N)");
                char continuar;
                bool continuarValido = char.TryParse(Console.ReadLine().ToUpper(), out continuar);

                while (!continuarValido || (continuar != 'S' && continuar != 'N'))
                {
                    Console.WriteLine("Opção inválida. Por favor, escolha novamente.");
                    continuarValido = char.TryParse(Console.ReadLine().ToUpper(), out continuar);
                }

                if (continuar == 'N')
                    continua = false;

                Console.Clear();
            }
        }
    }
}
