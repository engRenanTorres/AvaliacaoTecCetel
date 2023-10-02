using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCitel.DTOs;
using MVCCitel.Models;
using MVCCitel.Models.Domain;
using MVCCitel.Services.Interfaces;

namespace MVCCitel.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(
          ILogger<ProductController> logger,
          IProductService productService,
          ICategoryService categoryService
        )
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _productService.GetAllProducts();
            return View( categories );
        }
        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var product = await _productService.GetProduct(id);
            if (product != null) {
                var viewModel = new UpdateProductViewModel{
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    CreatedAt = product.CreatedAt
                };
                return await Task.Run(()=>View("View",viewModel));
            }
            return RedirectToAction("Server500","Error");

        }
        
        [HttpPost]
        public async Task<IActionResult> View(UpdateProductViewModel model)
        {

            var product = await _productService.GetProduct(model.Id);
            if(product == null)
            {
                return RedirectToAction("Server500","Error");
            }
            var updateDTO = new UpdateProductDTO{
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
            };
            try 
            {
                await _productService.PatchProduct(model.Id, updateDTO);

                return RedirectToAction("Index");
            } 
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return RedirectToAction("Server500","Error");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateProductViewModel model)
        {
            var product = await _productService.GetProduct(model.Id);
            if(product != null)
            {
               await _productService.DeleteProduct(product.Id);
               return RedirectToAction("Index");
            }
            return RedirectToAction("Server500","Error");
        }
        
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllCategories(); // Substitua pelo método correto para obter suas categorias
            var viewModel = new AddProductViewModel
            {
                Categories = categories.Select(c => new SelectListItem { Value = c?.Id.ToString(), Text = c?.Name }).ToList()
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateProductDTO createProductDTO)
        {
            if (createProductDTO == null) return RedirectToAction("Index"); // TODO redirect to proper error page;
            Product? product = await _productService.CreateProduct(createProductDTO);
            return product != null ?
                RedirectToAction("Add") :
                RedirectToAction("Server500","Error");
        }
    }
}
