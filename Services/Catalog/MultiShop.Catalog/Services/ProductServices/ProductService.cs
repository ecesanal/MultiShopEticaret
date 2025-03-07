﻿using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;


        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;

        }
        public async Task CreateProductAsync(CreateProductDto ProductDto)
        {
            var values = _mapper.Map<Product>(ProductDto);
            await _productCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var values = await _productCollection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(values);
        }

        
        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryDtoAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find<Category>(x => x.CategoryId == item.CategoryId).FirstAsync();
            }
            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string CategoryId)
        {
            var values = await _productCollection.Find<Product>(x => x.CategoryId==CategoryId).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find<Category>(x => x.CategoryId == item.CategoryId).FirstAsync();
            }
            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);
        }
    }
}
