using Microsoft.AspNetCore.Mvc;
using MVCCitel.Data.Repositories;
using MVCCitel.DTOs;
using MVCCitel.Models;
using MVCCitel.Models.Domain;
using MVCCitel.Services.Interfaces;
using System.ComponentModel;

namespace MVCCitel.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<IProductService> _logger;
        private readonly IProductRepository _productRepository;

        public ProductService(
          ILogger<IProductService> logger,
          IProductRepository repository
        )
        {
            _logger = logger;
            _productRepository = repository;
        }
        async public Task<Product?> CreateProduct(CreateProductDTO productDTO)
        {
            _logger.LogInformation("CreateProduct has been called.");

            Product product = new()
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                CreatedAt = DateTime.UtcNow,
                Price = productDTO.Price,
                CategoryId = productDTO.CategoryId
            };


            _productRepository.AddEntity(product);
            if (await _productRepository.SaveChanges())
            {
                return product;
            }
            return null;
        }

        async public Task<bool> DeleteProduct(int id)
        {
            _logger.LogInformation("Delete Product has been called.");

            Product product =
              await _productRepository.GetSingleProduct(id)
              ?? throw new WarningException("Product id: " + id + " not found");

            _productRepository.RemoveEntity<Product>(product);
            return await _productRepository.SaveChanges();
        }

        async public Task<Product?> GetProduct(int id)
        {
            _logger.LogInformation("Get One Product Service has been called.");

            Product? product = await _productRepository.GetSingleProduct(id);

            _logger.LogInformation("Get One Product Service has finish succefully.");
            return product;
        }

        async public Task<IEnumerable<Product?>> GetAllProducts()
        {
            _logger.LogInformation("Get Products Service has been called.");
            IEnumerable<Product?> products = await _productRepository.GetAllProducts();
            _logger.LogInformation("Get Products Service has finish succefully.");
            return products;
        }

        async public Task<Product> PatchProduct(int id, [FromBody] UpdateProductDTO updateProductDTO)
        {
            _logger.LogInformation("Patch ProductService has been called.");
            Product product =
              await _productRepository.GetSingleProduct(id)
              ?? throw new WarningException("Product id: " + id + " not found");

            if (updateProductDTO.Name != null) product.Name = updateProductDTO.Name;
            if (updateProductDTO.Description != null) product.Description = updateProductDTO.Description;

            if (await _productRepository.SaveChanges())
            {
                _logger.LogInformation("Patch ProductService has updated product successfully.");
                return product;
            }
            throw new Exception("Error to update Product");
        }
    }
}
