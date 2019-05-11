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
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public ActionResult<List<Contact>> Get()
        {
            return _contactService.Get();
        }

        [HttpGet("{id}", Name = "GetContact")]
        public ActionResult<Contact> Get(string id)
        {
            var contact = _contactService.Get(id);
            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        [HttpPost]
        public ActionResult<Contact> Create(Contact contact)
        {
            if(contact == null)
            {
                return NotFound();
            }

            _contactService.Create(contact);
            return CreatedAtRoute("GetContact", new { id = contact.Id.ToString() }, contact);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Contact contactIn)
        {
            var contact = _contactService.Get(id);

            if (contact == null)
            {
                return NotFound();
            }

            _contactService.Update(id, contactIn);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var contact = _contactService.Get(id);

            if (contact == null)
            {
                return NotFound();
            }

            _contactService.Remove(contact);
            return NoContent();
        }
    }
}