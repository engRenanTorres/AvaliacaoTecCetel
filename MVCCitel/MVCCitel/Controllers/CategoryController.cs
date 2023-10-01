using Microsoft.AspNetCore.Mvc;
using MVCCitel.DTOs;
using MVCCitel.Models;
using MVCCitel.Models.Domain;
using MVCCitel.Services.Interfaces;

namespace MVCCitel.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(
          ILogger<CategoryController> logger,
          ICategoryService categoryService
        )
        {
            _logger = logger;
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategories();
            return View( categories );
    
        }
        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var category = await _categoryService.GetCategory(id);
            if (category != null) {
                var viewModel = new UpdateCategoryViewModel{
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    CreatedAt = category.CreatedAt
                };
                return await Task.Run(()=>View("View",viewModel));
            }
            return RedirectToAction("Server500","Error");

        }
        
        [HttpPost]
        public async Task<IActionResult> View(UpdateCategoryViewModel model)
        {

            var category = await _categoryService.GetCategory(model.Id);
            if(category == null)
            {
                return RedirectToAction("Server500","Error");
            }
            var updateDTO = new UpdateCategoryDTO{
                Name = model.Name,
                Description = model.Description
            };
            await _categoryService.PatchCategory(model.Id, updateDTO);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateCategoryViewModel model)
        {
            var category = await _categoryService.GetCategory(model.Id);
            if(category != null)
            {
               await _categoryService.DeleteCategory(category.Id);
               return RedirectToAction("Index");
            }
            return RedirectToAction("Server500","Error");
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryDTO createCategoryDTO)
        {
            if (createCategoryDTO == null) return RedirectToAction("Index"); // TODO redirect to proper error page;
            Category? category = await _categoryService.CreateCategory(createCategoryDTO);
            return category != null ?
                RedirectToAction("Add") :
                RedirectToAction("Server500","Error");
        }
    }
}
