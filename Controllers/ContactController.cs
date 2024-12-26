using ContactManagementAPI.Models;
using ContactManagementAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace ContactManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("Allow")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetContactList()
        {
            var contact = await _contactService.GetAllContact();
            return Ok(contact);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await _contactService.GetContactById(id);
            if (contact == null)
            {
                return NotFound(new ErrorDetails { StatusCode = 404, Message = $"Contact with Id {id} was not found." });

            }
            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest("Contact is null.");
            }

            await _contactService.AddNewContact(contact);
            return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateContact(int id, [FromBody] Contact contact)
        {
            await _contactService.UpdateContact(contact);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            var contact = await _contactService.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }
            await _contactService.DeleteContact(id);
            return NoContent();
        }
    }
}
