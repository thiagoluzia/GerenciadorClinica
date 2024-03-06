using GC.Application.ExternalServices.ViaCEP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GC.Application.Services.Implementations.Tests
{
    [TestClass()]
    public class ViaCEPServiceTests
    {
        
        [TestMethod()]
        public void ConsultarCepTest()
        {
            var cep = "12312270";
            var _httpClient = new HttpClient();

            var integracao = new ViaCEPService(_httpClient);



            var result = integracao.ConsultarCep(cep);

            Assert.IsTrue(result.Result.Bairro.Equals("Cidade Salvador"));
        }
    }
}