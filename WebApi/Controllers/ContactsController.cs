using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Business;
using WebApi.Domain;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(ContactService service, IMapper mapper, ILogger<ContactsController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await _service.GetAllContactsAsync();
            var contactsDto = _mapper.Map<IEnumerable<ContactDTO>>(contacts);

            return Ok(contactsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var contact = await _service.GetContactByIdAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            var contactDto = _mapper.Map<ContactDTO>(contact);

            return Ok(contactDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] CreateContactDTO createContactDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Contact {createContactDto.FirstName} {createContactDto.LastName} adding has been failed");

                return BadRequest(ModelState);
            }
            var contact = _mapper.Map<Contact>(createContactDto);
            await _service.AddContactAsync(contact);
            var contactDto = _mapper.Map<ContactDTO>(contact);

            _logger.LogInformation($"Contact {contactDto.FirstName} {contactDto.LastName} has been added");

            return CreatedAtAction(nameof(GetContactById), new { id = contactDto.Id }, contactDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] UpdateContactDTO updateContactDto)
        {
            if (id != updateContactDto.Id)
            {
                _logger.LogError($"Contact {updateContactDto.FirstName} {updateContactDto.LastName} update has been failed");

                return BadRequest();
            }

            var contact = _mapper.Map<Contact>(updateContactDto);
            await _service.UpdateContactAsync(contact);

            _logger.LogInformation($"Contact {contact.FirstName} {contact.LastName} has been updated");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _service.DeleteContactAsync(id);

            _logger.LogInformation($"Contact Id={id} has been removed");

            return NoContent();
        }
    }
}
