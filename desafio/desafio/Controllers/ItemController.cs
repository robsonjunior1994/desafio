using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio.Models;
using desafio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public ActionResult<List<Item>> Get()
        {
            return _itemService.Get();
        }

        [HttpGet("BuscarTipo/{type}")]
        public ActionResult<List<Item>> BuscarTipo(string type)
        {
            Item itemVerificador = new Item();
            itemVerificador.Type = type;
            itemVerificador.State = type;

            if (type == "CD" || type == "DVD" || type == "Livro" ||
                    type == "Disponível" || type == "Indisponível")
            {
                var item = _itemService.BuscarTipo(type);
                return item;
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpGet("{id}", Name = "GetItem")]
        public ActionResult<Item> Get(string id)
        {
            Item item = null;
            if(id.Length > 0)
            {
                item = _itemService.Get(id);
                if (item == null)
                {
                    return NotFound();
                }
            }
                return item;
        }

        [HttpGet("Buscar/{name}")]  // seu get vai controller/buscar/name
        public ActionResult<Item> Buscar(string name)
        {
            Item item = null;
            if(name.Length > 0)
            {
                item = _itemService.Buscar(name);
                if (item == null)
                {
                    return NotFound();
                }
            }

            return item;
        }

        [HttpPost]
        public ActionResult<Item> Create(Item item)
        {
            if(item == null)
            {
                return NotFound();
            }
            if (item.Name.Length > 1 && item.BorrowedTo == "Ninguém" && item.State == "Disponível" || item.State == "Indisponível")
            {
                _itemService.Create(item);
                return CreatedAtRoute("GetItem", new { id = item.Id.ToString() }, item);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Item itemIn)
        {
            Item item;

            if(id.Length > 0)
            {
                item = _itemService.Get(id);
            }

            if (itemIn == null)
            {
                return NotFound();
            }
            if (itemIn.Name.Length > 1 && itemIn.State == "Disponível" || itemIn.State == "Indisponível")
            {
                _itemService.Update(id, itemIn);
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if(id.Length > 0)
            {
                var item = _itemService.Get(id);
                if (item == null)
                {
                    return NotFound();
                }

                _itemService.Remove(item);
                return NoContent();
            }

            return NotFound();
            
           
        }

    }
}