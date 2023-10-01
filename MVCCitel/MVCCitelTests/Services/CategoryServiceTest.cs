using Microsoft.Extensions.Logging;
using MVCCitel.Data.Repositories;
using MVCCitel.DTOs;
using MVCCitel.Models;
using MVCCitel.Models.Domain;
using MVCCitel.Services;
using MVCCitel.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCitelTests.Services
{
    public class CategoryServiceTest
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<ICategoryService> _logger;
        private readonly CategoryService _categoryService;
        private readonly Category _category = new()
        {
            Id = 1,
            CreatedAt = new DateTime(2020, 07, 02, 22, 59, 59),
            Description = "Is this a quetion Test?",
            Name = "Test"
        };

        public CategoryServiceTest()
        {
            _categoryRepository = A.Fake<ICategoryRepository>();
            _logger = A.Fake<ILogger<ICategoryService>>();
            _categoryService = new CategoryService(_logger, _categoryRepository);
        }


        [Fact]
        public async Task GetCategory_BDContainTheCategory_ShouldReturnCategory()
        {
            var id = 1;
            A.CallTo(() => _categoryRepository.GetSingleCategory(id)).Returns(Task.FromResult<Category?>(_category));

            var result = await _categoryService.GetCategory(id);

            result?.Should().BeOfType<Category>();
            result?.Should().BeSameAs(_category);
        }

        [Fact]
        public async Task GetAllCategory_BDContainTheCategory_ShouldReturnCategorys()
        {
            var categorys = new List<Category>
            {
                _category
            };
            A.CallTo(() => _categoryRepository.GetAllCategories()).Returns(categorys);

            var result = await _categoryService.GetAllCategories();

            result?.Should().BeOfType<List<Category>>();

            result?.Should().BeSameAs(categorys);
        }

        [Fact]
        public async Task DeleteCategory_BDContainTheCategory_ShouldReturnTrue()
        {
            var categoryId = 1;

            A.CallTo(() => _categoryRepository.GetSingleCategory(categoryId)).Returns(Task.FromResult<Category?>(_category));
            A.CallTo(() => _categoryRepository.RemoveEntity(_category));
            A.CallTo(() => _categoryRepository.SaveChanges()).Returns(Task.FromResult<bool>(true));

            var result = await _categoryService.DeleteCategory(categoryId);

            result.Should().Be(true);
        }

        [Fact]
        public async Task DeleteCategory_NotFoundCategory_ShouldThrowWarning()
        {
            var categoryId = 1;

            A.CallTo(() => _categoryRepository.GetSingleCategory(categoryId)).Returns(Task.FromResult<Category?>(null));

            try
            {
                var result = await _categoryService.DeleteCategory(categoryId);
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<WarningException>();
                ex.Message.Should().Be("Category id: 1 not found");
            }

        }

        [Fact]
        public async Task DeleteCategory_UnnableToDelete_SouldReturnFalse()
        {
            var Id = 1;

            A.CallTo(() => _categoryRepository
                .GetSingleCategory(Id))
                .Returns(Task.FromResult<Category?>(null));
            A.CallTo(() => _categoryRepository.RemoveEntity(_category));
            A.CallTo(() => _categoryRepository
                .SaveChanges()).Returns(Task.FromResult<bool>(false));
            try
            { 
                var result = await _categoryService.DeleteCategory(Id);
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<WarningException>();
                ex.Message.Should().Be("Category id: 1 not found");
            }
        }

        [Fact]
        public async Task PatchCategory_updateSucessfully_ShouldReturnCategory()
        {
            var updateCategoryDTO = new UpdateCategoryDTO();
            var categoryId = 1;

            A.CallTo(() => _categoryRepository
                .GetSingleCategory(categoryId))
                .Returns(Task.FromResult<Category?>(_category));
            A.CallTo(() => _categoryRepository
                .SaveChanges()).Returns(Task.FromResult<bool>(true));


            var result = await _categoryService
                .PatchCategory(categoryId, updateCategoryDTO);

            result.Should().Be(_category);
        }


        [Fact]
        public async Task PatchCategory_NotFoundCategory_ShouldThrowWarnning()
        {
            var updateCategoryDTO = new UpdateCategoryDTO();
            var quesitonId = 1;

            A.CallTo(() => _categoryRepository.GetSingleCategory(quesitonId))
                .Returns(Task.FromResult<Category?>(null));
            try
            {
                var result = await _categoryService
                    .PatchCategory(quesitonId, updateCategoryDTO);
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<WarningException>();
            }
        }

        [Fact]
        public async Task CreateCategory_CreateSucessfully_ShouldReturnCategory()
        {
            var categoryDTO = new CreateCategoryDTO()
            {
                Description = "Is this a quetion Test?",
                Name = "Test",
            };

            A.CallTo(() => _categoryRepository
                .AddEntity(categoryDTO));
            A.CallTo(() => _categoryRepository
                .SaveChanges()).Returns(Task.FromResult<bool>(true));


            var result = await _categoryService
                .CreateCategory(categoryDTO);

            result?.Name.Should().Be(_category.Name);
            result?.Description.Should().Be(_category.Description);
        }
    }
}
