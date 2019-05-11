using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio.Models
{
    interface IContactService
    {
        List<Contact> Get();
        Contact Get(string id);
        Contact Create(Contact contact);
        void Update(string id, Contact contactIn);
        void Remove(Contact contactIn);
        void Remove(string id);
    }
}
