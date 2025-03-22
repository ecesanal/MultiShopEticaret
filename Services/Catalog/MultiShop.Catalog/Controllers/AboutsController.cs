using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Services.AboutServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _AboutService;
        private readonly IDatabaseSettings _databaseSettings;
        public AboutsController(IAboutService AboutService, IDatabaseSettings databaseSettings)
        {
            _AboutService = AboutService;
            _databaseSettings = databaseSettings;
        }
        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _AboutService.GetAllAboutAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(string id)
        {
            var values = await _AboutService.GetByIdAboutAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _AboutService.CreateAboutAsync(createAboutDto);
            return Ok("Hakkında Başarıyla Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteteAbout(string id)
        {
            await _AboutService.DeleteAboutAsync(id);
            return Ok("Hakkında Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _AboutService.UpdateAboutAsync(updateAboutDto);
            return Ok("Hakkında Başarıyla Güncellendi");
        }
    }
}
