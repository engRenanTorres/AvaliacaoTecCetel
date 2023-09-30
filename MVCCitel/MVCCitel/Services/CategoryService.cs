using Microsoft.AspNetCore.Mvc;
using MVCCitel.Data.Repositories;
using MVCCitel.DTOs;
using MVCCitel.Models;
using MVCCitel.Models.Domain;
using MVCCitel.Services.Interfaces;
using System.ComponentModel;

namespace MVCCitel.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ILogger<ICategoryService> _logger;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(
          ILogger<ICategoryService> logger,
          ICategoryRepository repository
        )
        {
            _logger = logger;
            _categoryRepository = repository;
        }
        async public Task<Category?> CreateCategory(AddCategoryViewModel categoryDTO)
        {
            _logger.LogInformation("CreateCategory has been called.");

            Category category = new()
            {
                Name = categoryDTO.Name,
                Description = categoryDTO.Description,
                CreatedAt = DateTime.UtcNow
            };


            _categoryRepository.AddEntity(category);
            if (await _categoryRepository.SaveChanges())
            {
                return category;
            }
            return null;
        }

        async public Task<bool> DeleteCategory(int id)
        {
            _logger.LogInformation("Delete Category has been called.");

            Category category =
              await _categoryRepository.GetSingleCategory(id)
              ?? throw new WarningException("Category id: " + id + " not found");

            _categoryRepository.RemoveEntity<Category>(category);
            return await _categoryRepository.SaveChanges();
        }

        async public Task<Category?> GetCategory(int id)
        {
            _logger.LogInformation("Get One Category Service has been called.");

            Category? category = await _categoryRepository.GetSingleCategory(id);

            _logger.LogInformation("Get One Category Service has finish succefully.");
            return category;
        }

        async public Task<IEnumerable<Category?>> GetAllCategories()
        {
            _logger.LogInformation("Get Categorys Service has been called.");
            IEnumerable<Category?> categorys = await _categoryRepository.GetAllCategories();
            _logger.LogInformation("Get Categorys Service has finish succefully.");
            return categorys;
        }

        async public Task<Category> PatchCategory(int id, [FromBody] UpdateCategoryDTO updateCategoryDTO)
        {
            _logger.LogInformation("Patch CategoryService has been called.");
            Category category =
              await _categoryRepository.GetSingleCategory(id)
              ?? throw new WarningException("Category id: " + id + " not found");

            if (updateCategoryDTO.Name != null) category.Name = updateCategoryDTO.Name;
            if (updateCategoryDTO.Description != null) category.Description = updateCategoryDTO.Description;

            if (await _categoryRepository.SaveChanges())
            {
                _logger.LogInformation("Patch CategoryService has updated category successfully.");
                return category;
            }
            throw new Exception("Error to update Category");
        }
    }
}
