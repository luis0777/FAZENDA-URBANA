# Resumo sobre a PoC 📖📖📖

# 1. Program.cs 🧑‍💻
Método Main: Ponto de entrada do programa. Exibe mensagem de boas-vindas, solicita tipo de login (Cliente ou Administrador) e controla a saída do programa. Inclui um bloco try-catch para tratamento de exceções e uma variável loginValido para controle de fluxo.
Métodos Auxiliares:
ExibirMensagemInicial(): Mostra mensagens animadas na tela inicial.
EncerrarPrograma(): Exibe contagem regressiva antes de fechar o programa.

## 2. TelaAdm.cs 🖥️
Método Admin: Autentica o login do administrador, verificando usuário e senha. Se bem-sucedido, exibe um menu para gerenciamento do sistema.
Método admLogado: Oferece um menu com opções para gerenciar clientes, funcionários, fornecedores, produtos, matéria-prima e vendas.

## 3. ClienteFazerLogin.cs 
Controla o processo de login dos clientes. Solicita CPF e senha, verifica as credenciais e redireciona o cliente para a próxima etapa ou solicita nova tentativa.

## 4. ClienteLoginOuCadastro.cs
Interação inicial com o cliente, permitindo escolha entre cadastro e login. Chamadas para métodos de cadastro e login.

## 5. ClienteVenda.cs
Gerencia o processo de compra do cliente, exibindo produtos e aceitando seleções.
ProcessarVenda: Verifica a disponibilidade do produto, calcula o valor total e atualiza o banco de dados.
RegistrarVenda: Insere detalhes da venda no banco de dados e fornece feedback ao usuário.

## 6. MostrarVendas
Exibe todas as vendas realizadas com detalhes.

## 7. ExcluirFornecedor.cs
Remove um fornecedor do banco de dados. Solicita o ID do fornecedor, executa a consulta SQL e fornece feedback sobre o sucesso ou falha da operação.

## 8. FornecedorCadastro.cs
Coleta dados do fornecedor e os insere no banco de dados, realizando validações.

## 9. FuncionarioCadastro.cs
Gerencia operações relacionadas a funcionários, como cadastro, remoção e alteração de funções.

## 10. MateriaPrima.cs
Exibe informações sobre matérias-primas fornecidas pelos fornecedores cadastrados.

## 11. ProdutoCadastrado.cs
MostrarProduto: Exibe todas as informações dos produtos cadastrados.
AlterarProduto: Permite alterar informações de um produto, como quantidade e preço.

## 12. ClienteCadastro.cs
Interage com o usuário para coletar informações para cadastro de um novo cliente. Realiza validações e insere os dados no banco de dados.

## 13. ClienteCadastrado.cs
Recupera e exibe informações de todos os clientes cadastrados no banco de dados.

## Considerações Finais
A documentação fornece uma visão abrangente sobre a estrutura e funcionamento da aplicação, detalhando cada classe e método, além de suas funcionalidades e fluxos. O código segue boas práticas de segurança, como a utilização de parâmetros nas consultas SQL para evitar injeções.
