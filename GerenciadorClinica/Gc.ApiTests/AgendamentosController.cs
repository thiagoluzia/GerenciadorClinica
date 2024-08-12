using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Gc.ApiTests
{
    [TestClass]
    public class AgendamentosController
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var agendamentos = new List<Agendamento> { new Agendamento() };

            mediatorMock.Setup(m => m.Send(It.IsAny<BuscarAgendamentosQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(agendamentos);

            var controller = new AgendamentosController(mediatorMock.Object);
        }
    }
}
