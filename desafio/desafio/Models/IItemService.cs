using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio.Models
{
    public interface IItemService
    {
        List<Item> Get();
        List<Item> BuscarTipo(string filtro);
        List<Item> VerificarStatus(string status);
        Item Get(string id);
        Item Buscar(string keyword);
        Item Create(Item item);
        void Update(string id, Item item);
        void Remove(Item item);
        void Remove(string id);


    }
}
