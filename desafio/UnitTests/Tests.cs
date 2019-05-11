using System;
using System.Collections.Generic;
using System.Text;
using desafio.Controllers;
using desafio.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;

namespace UnitTests
{
    public class Tests
    {
        internal ItemController sutItem;
        internal Mock<IItemService> itemServiceMock;
        internal ContactController sutContact;
        internal Mock<IContactService> contactServiceMock;
        

        public void CriarItemController()
        {
            sutItem = new ItemController(itemServiceMock.Object)
            {
               
            };
        }

        public void CriarContactController()
        {
            sutContact = new ContactController(contactServiceMock.Object)
            {

            };
        }

        public void CriarMock()
        {
            this.itemServiceMock = new Mock<IItemService>();
            this.contactServiceMock = new Mock<IContactService>();

        }
    }
}
