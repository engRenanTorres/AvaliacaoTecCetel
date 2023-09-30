using System.ComponentModel.DataAnnotations;

namespace MVCCitel.DTOs
{
    public class CreateCategoryDTO
    {
        [Required]
        public string Name { get; set; } = "";
        public string? Description { get; set; }
    }
}
