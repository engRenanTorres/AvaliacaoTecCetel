using System.ComponentModel.DataAnnotations;

namespace MVCCitel.DTOs
{
    public class UpdateCategoryDTO
    {
        public string? Name { get; set; } = "";
        public string? Description { get; set; }
    }
}
