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
        public ActionResult<List<Item>> FiltrarPorTipoDoItem(string type)
        {
            Item itemVerificador = new Item();
            itemVerificador.Type = type;
            //itemVerificador.State = type;

            if (type == "CD" || type == "DVD" || type == "Livro" ||
                    type == "disponivel" || type == "indisponivel")
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
            if (string.IsNullOrEmpty(id))
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
            if (string.IsNullOrEmpty(name))
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
            if (item == null)
            {
                return NotFound();
            }
            if (item.Name.Length > 1 && item.BorrowedTo == "ninguem" && item.State == "disponivel" || item.State == "indisponivel")
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

            if (id.Length > 0)
            {
                item = _itemService.Get(id);
            }

            if (itemIn == null)
            {
                return NotFound();
            }
            if (itemIn.Name.Length > 1 && itemIn.State == "disponivel" || itemIn.State == "indisponivel")
            {
                _itemService.Update(id, itemIn);
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (id.Length > 0)
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

        [HttpGet("FiltrarPorStatus/{status}")]
        public ActionResult<List<Item>> FiltrarPorStatus(string status)
        {

            if (string.IsNullOrEmpty(status))
            {
                return BadRequest();
            }

            else
            {
                List<Item> listaFiltradaPorStatus;

                var variavelDeStatusTratada = Item.TratandoFiltroDeStatus(status);

                if (Item.VerificarSeStatusTemOsValoresValidos(variavelDeStatusTratada))
                {
                    listaFiltradaPorStatus = _itemService.FiltrarPorStatus(variavelDeStatusTratada);
                }
                else
                {
                    listaFiltradaPorStatus = new List<Item>();
                }

                return listaFiltradaPorStatus;
            }
        }
    }
}