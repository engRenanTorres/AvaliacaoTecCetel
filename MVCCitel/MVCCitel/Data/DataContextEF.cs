using Microsoft.EntityFrameworkCore;
using MVCCitel.Models.Domain;

namespace MVCCitel.Data
{
    public class DataContextEF : DbContext
    {

        public DataContextEF(DbContextOptions<DataContextEF> options) : base(options)
        {
            // _conectionString = config.GetConnectionString("DefaultConnection");
        }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
              .HasMany(c => c.Products)
              .WithOne(p => p.Category)
              .IsRequired();
        }

    }
}
