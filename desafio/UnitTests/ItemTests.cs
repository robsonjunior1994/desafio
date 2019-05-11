using desafio.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class ItemTests : Tests
    {
        [Trait("ItemController","Buscar item por tipo")]
        [Fact(DisplayName = "DeveriaListarOsItensQueSelecioneiOtipo")]
        public void DeveriaListarTodosOsItems()
        {
            //Arrange
            CriarMock();

            //Act
            CriarItemController();
            itemServiceMock.Setup(x => x.BuscarTipo(It.IsAny<string>())).Returns(new List<Item>());
            //sutItem.BuscarTipo("DVD");
            //Assert
        }
    }
}
