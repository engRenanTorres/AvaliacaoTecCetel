using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MVCCitel.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Column(name: "Created_at")]
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; } = "";

        public decimal Price { get; set; } = 0m;

        public string? Description { get; set; } = "";
        public int CategoryId { get; set; }
        //[JsonIgnore]
        //[ForeignKey("Categories")]
        public Category? Category { get; set; }
    }
}
