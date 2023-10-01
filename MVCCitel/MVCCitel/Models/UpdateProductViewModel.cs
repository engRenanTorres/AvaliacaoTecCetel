namespace MVCCitel.Models
{
    public class UpdateProductViewModel
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public decimal Price { get; set; } = 0m;
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}