namespace MVCCitel.Models
{
    public class UpdateCategoryViewModel
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}