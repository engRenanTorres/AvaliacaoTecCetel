using System.ComponentModel.DataAnnotations;

namespace MVCCitel.DTOs
{
    public class UpdateProductDTO
    {
        public string? Name { get; set; } = "";
        public string? Description { get; set; }
        public decimal Price { get; set; } = 0m;
        public int CategoryId { get; set; }
    }
}
