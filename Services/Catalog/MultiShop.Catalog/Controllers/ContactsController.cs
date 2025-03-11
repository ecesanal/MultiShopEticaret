using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.ContactServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Controllers
{

    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _ContactService;
        private readonly IDatabaseSettings _databaseSettings;
        public ContactsController(IContactService ContactService, IDatabaseSettings databaseSettings)
        {
            _ContactService = ContactService;
            _databaseSettings = databaseSettings;
        }
        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _ContactService.GetAllContactAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(string id)
        {
            var values = await _ContactService.GetByIdContactAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            await _ContactService.CreateContactAsync(createContactDto);
            return Ok("Mesaj Başarıyla Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteteContact(string id)
        {
            await _ContactService.DeleteContactAsync(id);
            return Ok("Mesaj Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            await _ContactService.UpdateContactAsync(updateContactDto);
            return Ok("Mesaj Başarıyla Güncellendi");
        }
    }
}
