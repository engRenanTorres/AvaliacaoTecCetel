using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCCitel.Models
{
    public class AddProductViewModel
    {
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public decimal Price { get; set; } = 0m;
        public int CategoryId { get; set; }
        public List<SelectListItem>? Categories { get; set; }
        
    }
}