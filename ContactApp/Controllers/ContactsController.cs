using AutoMapper;
using ContactsApp.Core.Dtos;
using ContactsApp.Core.Models;
using ContactsApp.Service.ActionFilters;
using ContactsApp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ContactsApp.Core.Dtos.ContactDto;

namespace ContactsApp.API.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : BaseApiController
    {
        public ContactsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
        {
        }

        [HttpPost]
        [Route("create")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateContact([FromBody] ContactCreationDto contact)
        {
            var contactData = _mapper.Map<Contact>(contact);
            await _repository.Contact.CreateContact(contactData);
            await _repository.SaveAsync();
            var contactReturn = _mapper.Map<ContactDto>(contactData);
            return CreatedAtRoute("ContactById",
                new
                {
                    contactId = contactReturn.Id
                },
                contactReturn);
        }


        [HttpGet]
        [Route("allContacts")]
        [Authorize]
        [ResponseCache(CacheProfileName = "30SecondsCaching")]
        public async Task<IActionResult> GetContacts()
        {
            try
            {
                var contacts = await _repository.Contact.GetAllContacts(trackChanges: false);
                var contactsDto = _mapper.Map<IEnumerable<ContactDto>>(contacts);
                return Ok(contactsDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetContacts)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("names")]
        [ResponseCache(CacheProfileName = "30SecondsCaching")]
        public async Task<IActionResult> GetContactsNames()
        {
            try
            {
                var contacts = await _repository.Contact.GetAllContacts(trackChanges: false);
                var contactsDto = _mapper.Map<IEnumerable<ContactDto>>(contacts);
                return Ok(contactsDto.Select(c => c.Name));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetContacts)} action {ex}");
                return StatusCode(500, $"Internal server error {ex}");
            }
        }

        [HttpGet("details/{contactId}", Name = "contactById")]
        [Authorize]
        public async Task<IActionResult> GetContact(int contactId)
        {
            var contact = await _repository.Contact.GetContact(contactId, trackChanges: false);
            if (contact is null)
            {
                _logger.LogInfo($"Contact with id: {contactId} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var contactDto = _mapper.Map<ContactDto>(contact);
                return Ok(contactDto);
            }
        }


        [HttpPut("update/{contactId}")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateContactExists))]
        public async Task<IActionResult> UpdateContact(int contactId, [FromBody] ContactCreationDto contact)
        {
            var contactData = HttpContext.Items["contact"] as Contact;
            _mapper.Map(contact, contactData);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
