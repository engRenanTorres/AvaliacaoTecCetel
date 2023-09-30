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
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryViewModel addCategoryRequest)
        {
            if (addCategoryRequest == null) return BadRequest("Question data is null.");
            Category? category = await _categoryService.CreateCategory(addCategoryRequest);
            return category != null ?
                RedirectToAction("Add") :
                BadRequest("Category has Not been Created");
        }
    }
}
