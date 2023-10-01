using Microsoft.AspNetCore.Mvc;
using MVCCitel.Models.Domain;
using MVCCitel.DTOs;
using MVCCitel.Models;

namespace MVCCitel.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product?> CreateProduct(CreateProductDTO productDTO);
        Task<Product?> GetProduct(int id);
        Task<IEnumerable<Product?>> GetAllProducts();
        Task<Product> PatchProduct(int id, [FromBody] UpdateProductDTO updateProductDTO);
        Task<bool> DeleteProduct(int id);
    }
}
