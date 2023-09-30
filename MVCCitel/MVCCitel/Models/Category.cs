using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace MVCCitel.Models
{
    [Index(nameof(Category.Name), IsUnique = true)]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(name: "Created_at")]
        public DateTime CreatedAt { get; set; }
        [Required(ErrorMessage = "Informe o nome")]
        public string Name { get; set; } = "";
        public string? Description { get; set; } = "";
        [JsonIgnore]
        public ICollection<Product>? Products { get; set; }
    }
}
