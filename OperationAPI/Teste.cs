using Intefration.OperationAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OperationAPI
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public async Task TestEntrar()
        {
            // Arrange
            string id = "seuId";
            string senha = "suaSenha";
            AnalistaRH analistaRH = new AnalistaRH();

            // Act
            string resultado = await AnalistaRH.Entrar(id, senha);

            // Assert
            // Inclua as asserções para verificar se o resultado está correto
            Assert.IsNotNull(resultado);
            // Adicione as asserções apropriadas com base no comportamento esperado
        }
    }
}
