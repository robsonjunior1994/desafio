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
            Item itemIn = new Item();
            itemIn.Name = keyword;
            //return _items.Find<Item>(item => item.Name == LIKE keyword).FirstOrDefault();
            //return _items.Find<Item>(item => item.Name == itemIn.Name).FirstOrDefault();
            //return _items.find({$text: {$search: "Sorriso"} });
            //return collection.Find()
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
