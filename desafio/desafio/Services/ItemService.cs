using desafio.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio.Services
{
    public class ItemService
    {
        private readonly IMongoCollection<Item> _items;

        public ItemService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("DesafioDb"));
            var database = client.GetDatabase("DesafioDb");
            _items = database.GetCollection<Item>("Items");
        }

        public List<Item> Get()
        {
            return _items.Find(item => true).ToList();
        }

        public Item Get(string id)
        {
            return _items.Find<Item>(item => item.Id == id).FirstOrDefault();
        }

        public Item Buscar(string keyword)
        {
            //Colocar verificação se keyword for vazinho buscar o metodo get que retorna tudo ou alaramr que não foi encontrado
     
            Item itemIn = new Item();
            itemIn.Name = keyword;

            var itemUp = _items.Find<Item>(item => item.Name.ToLower() == itemIn.Name.ToLower()).FirstOrDefault();
            return itemUp;
        }
        
        public Item Create(Item item)
        {
            _items.InsertOne(item);
            return item;
        }

        public void Update(string id, Item itemIn)
        {
            _items.ReplaceOne(item => item.Id == id, itemIn);
        }

        public void Remove(Item itemIn)
        {
            _items.DeleteOne(item => item.Id == itemIn.Id);
        }

        public void Remove(string id)
        {
            _items.DeleteOne(item => item.Id == id);
        }
    }
}
