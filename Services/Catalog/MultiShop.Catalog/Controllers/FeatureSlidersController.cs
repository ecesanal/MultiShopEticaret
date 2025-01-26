using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.FeatureSliderServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : Controller
    {
        private readonly IFeatureSliderService _FeatureSliderService;
        private readonly IDatabaseSettings _databaseSettings;
        public FeatureSlidersController(IFeatureSliderService FeatureSliderService, IDatabaseSettings databaseSettings)
        {
            _FeatureSliderService = FeatureSliderService;
            _databaseSettings = databaseSettings;
        }
        [HttpGet]
        public async Task<IActionResult> FeatureSliderList()
        {
            var values = await _FeatureSliderService.GetAllFeatureSliderAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureSliderById(string id)
        {
            var values = await _FeatureSliderService.GetByIdFeatureSliderAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _FeatureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return Ok("Öne çıkan görsel Başarıyla Eklendi");
        }
        //db test
        [HttpGet("TestMongoConnection")]
        public IActionResult TestMongoConnection()
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            var collection = database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName);

            if (collection != null)
            {
                return Ok("MongoDB bağlantısı başarılı.");
            }

            return StatusCode(500, "MongoDB bağlantısı başarısız.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteteFeatureSlider(string id)
        {
            await _FeatureSliderService.DeleteFeatureSliderAsync(id);
            return Ok("Öne çıkan görsel Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _FeatureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return Ok("Öne çıkan görsel Başarıyla Güncellendi");
        }
    }
}
