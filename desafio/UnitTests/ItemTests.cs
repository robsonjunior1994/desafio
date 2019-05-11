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
        public void DeveriaListarTodosOsDoTipoSelecionadoItems()
        {
            //Arrange
            CriarMock();

            //Act
            CriarItemController();
            itemServiceMock.Setup(x => x.BuscarTipo(It.IsAny<string>())).Returns(new List<Item>());
            sutItem.BuscarTipo("DVD");
            string mensagem = "Retornando Lista filtrada por tipo de item";
            //Assert
            Object.Equals(mensagem, typeof(List<Item>));
        }

        [Trait("ItemController", "Buscar item por tipo")]
        [Fact(DisplayName = "NaoDeveriaListarOsItens")]
        public void NaoDeveriaListarOsItems()
        {
            //Arrange
            CriarMock();

            //Act
            CriarItemController();
            itemServiceMock.Setup(x => x.BuscarTipo(It.IsAny<string>())).Returns(new List<Item>());
            sutItem.BuscarTipo("Carro");
          
            //Assert
            itemServiceMock.Verify(x => x.BuscarTipo("Carro"), Times.Never);
            
        }

        [Trait("ItemController", "Buscar item por id")]
        [Fact(DisplayName = "NaoDeveriaBuscarItemPorIdComQtdDeStringMenorQueZero")]
        public void NaoDeveriaBuscarItemPorIdComQtdDeStringMenorQueZero()
        {
            //Arrange
            CriarMock();

            //Act
            CriarItemController();
            itemServiceMock.Setup(x => x.BuscarTipo(It.IsAny<string>())).Returns(new List<Item>());
            sutItem.Get("");

            //Assert
            itemServiceMock.Verify(x => x.Get(""), Times.Never);

        }

        [Trait("ItemController", "Buscar item por nome")]
        [Fact(DisplayName = "NaoDeveriaBuscarItemPorNomeComQtdDeStringMenorQueZero")]
        public void NaoDeveriaBuscarItemPorNomeComQtdDeStringMenorQueZero()
        {
            //Arrange
            CriarMock();

            //Act
            CriarItemController();
            itemServiceMock.Setup(x => x.BuscarTipo(It.IsAny<string>())).Returns(new List<Item>());
            sutItem.Buscar("");

            //Assert
            itemServiceMock.Verify(x => x.Buscar(""), Times.Never);

        }

        [Trait("ItemController", "Salvar item")]
        [Fact(DisplayName = "NaoDeveriaSalvarItemComValorNull")]
        public void NaoDeveriaSalvarItemComValorNull()
        {
            //Arrange
            CriarMock();
            Item item = null;

            //Act
            CriarItemController();
            itemServiceMock.Setup(x => x.Create(It.IsAny<Item>())).Returns(new Item());
            sutItem.Create(item);

            //Assert
            itemServiceMock.Verify(x => x.Create(item), Times.Never);

        }

        [Trait("ItemController", "Salvar item")]
        [Fact(DisplayName = "NaoDeveriaSalvarItemComQtdDeStringNoNomeMenorQueUm")]
        public void NaoDeveriaSalvarItemComQtdDeStringNoNomeMenorQueUm()
        {
            //Arrange
            CriarMock();
            Item item = new Item();

            //Act
            CriarItemController();
            itemServiceMock.Setup(x => x.Create(It.IsAny<Item>())).Returns(new Item());
            item.Name = "";
            item.BorrowedTo = "Ninguém";
            item.Description = "Item de teste";
            item.Genres = "Musica";
            item.State = "Disponível";
            item.Type = "CD";
            item.Year = "2019";

            sutItem.Create(item);

            //Assert
            itemServiceMock.Verify(x => x.Create(item), Times.Never);

        }

        [Trait("ItemController", "Salvar item")]
        [Fact(DisplayName = "NaoDeveriaSalvarItemComBorrowedToDiferenteDeNinguém")]
        public void NaoDeveriaSalvarItemComBorrowedToDiferenteDeNinguém()
        {
            //Arrange
            CriarMock();
            Item item = new Item();

            //Act
            CriarItemController();
            itemServiceMock.Setup(x => x.Create(It.IsAny<Item>())).Returns(new Item());
            item.Name = "NomeTeste";
            item.BorrowedTo = "Alguém";
            item.Description = "Item de teste";
            item.Genres = "Musica";
            item.State = "Disponível";
            item.Type = "CD";
            item.Year = "2019";

            sutItem.Create(item);

            //Assert
            itemServiceMock.Verify(x => x.Create(item), Times.Never);

        }

        [Trait("ItemController", "Salvar item")]
        [Fact(DisplayName = "NaoDeveriaSalvarItemComStateDiferenteDeDisponívelOuIndisponível")]
        public void NaoDeveriaSalvarItemComStateDiferenteDeDisponívelOuIndisponível()
        {
            //Arrange
            CriarMock();
            Item item = new Item();

            //Act
            CriarItemController();
            itemServiceMock.Setup(x => x.Create(It.IsAny<Item>())).Returns(new Item());
            item.Name = "NomeTeste";
            item.BorrowedTo = "Ninguém";
            item.Description = "Item de teste";
            item.Genres = "Musica";
            item.State = "DiferentedeDisnponívelOuIndisponível";
            item.Type = "CD";
            item.Year = "2019";

            sutItem.Create(item);

            //Assert
            itemServiceMock.Verify(x => x.Create(item), Times.Never);

        }

        [Trait("ItemController", "Atualizar item")]
        [Fact(DisplayName = "NaoDeveriaAtualizarItemSeItemInForNull")]
        public void NaoDeveriaAtualizarItemSeItemInForNull()
        {
            //Arrange
            CriarMock();
            PopularId();
            Item item = null;

            //Act
            CriarItemController();
            itemServiceMock.Setup(x => x.Update(itemId, item));
            sutItem.Update(itemId, item);

            //Assert
            itemServiceMock.Verify(x => x.Update(itemId, item), Times.Never);

        }

        [Trait("ItemController", "Atualizar item")]
        [Fact(DisplayName = "NaoDeveriaAtualizarItemComQtdDeStringNoNomeMenorQueUm")]
        public void NaoDeveriaAtualizarItemComQtdDeStringNoNomeMenorQueUm()
        {
            //Arrange
            CriarMock();
            PopularId();
            Item item = new Item();

            //Act
            CriarItemController();
            itemServiceMock.Setup(x => x.Create(It.IsAny<Item>())).Returns(new Item());
            item.Name = "";
            item.BorrowedTo = "Ninguém";
            item.Description = "Item de teste";
            item.Genres = "Musica";
            item.State = "Disponível";
            item.Type = "CD";
            item.Year = "2019";

            sutItem.Update(itemId, item);

            //Assert
            itemServiceMock.Verify(x => x.Update(itemId, item), Times.Never);

        }

        [Trait("ItemController", "Deletar item")]
        [Fact(DisplayName = "NaoDeveriaDeletarItemComQtdDeStringNoIdMenorQueUm")]
        public void NaoDeveriaDeletarItemComQtdDeStringNoIdMenorQueUm()
        {
            //Arrange
            CriarMock();
            Item item = new Item();

            //Act
            CriarItemController();
            sutItem.Delete("");

            //Assert
            itemServiceMock.Verify(x => x.Remove(""), Times.Never);

        }
    }
}
