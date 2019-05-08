using desafio.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio.Services
{
    public class ContactService
    {
        private readonly IMongoCollection<Contact> _contact;

        public ContactService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("DesafioDb"));
            var database = client.GetDatabase("DesafioDb");
            _contact = database.GetCollection<Contact>("Contacts");
        }

        public List<Contact> Get()
        {
            return _contact.Find(contact => true).ToList();
        }

        public Contact Get(string id)
        {
            return _contact.Find<Contact>(contact => contact.Id == id).FirstOrDefault();
        }

        public Contact Create(Contact contact)
        {
            _contact.InsertOne(contact);
            return contact;
        }

        public void Update(string id, Contact contactIn)
        {
            _contact.ReplaceOne(contact => contact.Id == id, contactIn);
        }

        public void Remove(Contact contactIn)
        {
            _contact.DeleteOne(contact => contact.Id == contactIn.Id);
        }

        public void Remove(string id)
        {
            _contact.DeleteOne(contact => contact.Id == id);
        }
    }
}
