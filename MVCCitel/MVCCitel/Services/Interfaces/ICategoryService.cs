using Microsoft.AspNetCore.Mvc;
using MVCCitel.Models.Domain;
using MVCCitel.DTOs;
using MVCCitel.Models;

namespace MVCCitel.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Category?> CreateCategory(CreateCategoryDTO categoryDTO);
        Task<Category?> GetCategory(int id);
        Task<IEnumerable<Category?>> GetAllCategories();
        Task<Category> PatchCategory(int id, [FromBody] UpdateCategoryDTO updateCategoryDTO);
        Task<bool> DeleteCategory(int id);
    }
}
