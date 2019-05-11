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
            var item = _itemService.BuscarTipo(type);
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpGet("{id}", Name = "GetItem")]
        public ActionResult<Item> Get(string id)
        {
            var item = _itemService.Get(id);
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpGet("Buscar/{name}")]  // seu get vai controller/buscar/name
        public ActionResult<Item> Buscar(string name)
        {
            var item = _itemService.Buscar(name);
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public ActionResult<Item> Create(Item item)
        {
            _itemService.Create(item);
            return CreatedAtRoute("GetItem", new { id = item.Id.ToString() }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Item itemIn)
        {
            var item = _itemService.Get(id);

            if(item == null)
            {
                return NotFound();
            }

            _itemService.Update(id, itemIn);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var item = _itemService.Get(id);
            
            if(item == null)
            {
                return NotFound();
            }

            _itemService.Remove(item);
            return NoContent();
        }

    }
}