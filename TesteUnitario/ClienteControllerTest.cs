using Controller;
using Model;
using Moq;
using Util.BD;

namespace TesteUnitario
{
    [TestClass]
    public class ClienteControllerTest
    {        
        [TestMethod]
        public void IncluirCliente_DeveRetornarTrue_QuandoClienteIncluidoComSucesso()
        {
            // Arrange            
            var mockFactory = new Mock<SqlFactory>();            

            var clienteController = new ClienteController(mockFactory.Object);
            var clienteModel = new ClienteModel
            {
                NomeCliente = "Teste",
                Cpf = "12345678900",
                Email = "teste@teste.com",
                Senha = new byte[] { 1, 2, 3, 4, 5 }
            };

            // Act
            var resultado = clienteController.IncluirCliente(clienteModel);

            // Assert
            Assert.IsTrue(resultado);            
        }
        [TestMethod]
        public void IncluirCliente_DeveRetornarFalse_QuandoClienteJaCadastrado()
        {
            // Arrange            
            var mockFactory = new Mock<SqlFactory>();

            var clienteController = new ClienteController(mockFactory.Object);
            var clienteModel = new ClienteModel
            {
                NomeCliente = "Teste",
                Cpf = "12345678900",
                Email = "teste@teste.com",
                Senha = new byte[] { 1, 2, 3, 4, 5 }
            };

            // Act
            var resultado = clienteController.IncluirCliente(clienteModel);

            // Assert
            Assert.IsFalse(resultado);
        }
    }
}