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
            return View(category);

        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryDTO createCategoryDTO)
        {
            if (createCategoryDTO == null) return BadRequest("Question data is null.");
            Category? category = await _categoryService.CreateCategory(createCategoryDTO);
            return category != null ?
                RedirectToAction("Add") :
                BadRequest("Category has Not been Created");
        }
    }
}
