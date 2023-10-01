using Microsoft.AspNetCore.Mvc;
using MVCCitel.DTOs;
using MVCCitel.Models;
using MVCCitel.Models.Domain;
using MVCCitel.Services.Interfaces;

namespace MVCCitel.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<CategoryController> _logger;

        public ErrorController(
          ILogger<CategoryController> logger
        )
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Server500()
        {
            return View();
    
        }
    }
}
