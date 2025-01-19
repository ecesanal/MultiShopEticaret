using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IDatabaseSettings _databaseSettings;

        public ProductsController(IProductService productService,IDatabaseSettings databaseSettings)
        {
            _productService = productService;
            _databaseSettings = databaseSettings;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productService.GetAllProductAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createproductDto)
        {
            await _productService.CreateProductAsync(createproductDto);
            return Ok("Ürün Başarıyla Eklendi");
        }
        //db test
        [HttpGet("TestMongoConnection")]
        public IActionResult TestMongoConnection()
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            var collection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);

            if (collection != null)
            {
                return Ok("MongoDB bağlantısı başarılı.");
            }

            return StatusCode(500, "MongoDB bağlantısı başarısız.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Ürün Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateproductDto)
        {
            await _productService.UpdateProductAsync(updateproductDto);
            return Ok("Ürün Başarıyla Güncellendi");
        }
        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values=await _productService.GetProductsWithCategoryDtoAsync();
            return Ok(values);
        }
    }
}
