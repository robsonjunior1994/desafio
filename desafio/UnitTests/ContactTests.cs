using desafio.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests
{
    public class ContactTests : Tests
    {
        [Trait("ContactController", "Salvar contato")]
        [Fact(DisplayName = "NaoDeveriaSalvarContatoComValorNull")]
        public void NaoDeveriaSalvarContatoComValorNull()
        {
            //Arrange
            CriarMock();
            Contact contact = null;

            //Act
            CriarContactController();
            contactServiceMock.Setup(x => x.Create(It.IsAny<Contact>())).Returns(new Contact());
            sutContact.Create(contact);

            //Assert
            contactServiceMock.Verify(x => x.Create(contact), Times.Never);

        }

        [Trait("ContactController", "Atualizar contato")]
        [Fact(DisplayName = "NaoDeveriaAtualizarContatoComValorNull")]
        public void NaoDeveriaAtualizarContatoComValorNull()
        {
            //Arrange
            CriarMock();
            PopularId();
            Contact contact = null;

            //Act
            CriarContactController();
            contactServiceMock.Setup(x => x.Update(itemId, contact));
            sutContact.Update(itemId,contact);

            //Assert
            contactServiceMock.Verify(x => x.Update(itemId, contact), Times.Never);

        }
    }
}
