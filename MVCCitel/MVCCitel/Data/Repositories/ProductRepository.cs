using Microsoft.EntityFrameworkCore;
using MVCCitel.Models.Domain;

namespace MVCCitel.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContextEF _context;
        public ProductRepository(DataContextEF context)
        {
            _context = context;
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void AddEntity<T>(T entity)
        {
            if (entity != null)
            {
                _context.Add(entity);
            }
        }

        public void RemoveEntity<T>(T entity)
        {
            if (entity != null) { _context.Remove(entity); }
        }

        public async Task<IEnumerable<Product?>> GetAllProducts()
        {
            if (_context.Products != null)
            {
                IEnumerable<Product?> questions = await _context.Products
                  .Include(q => q.Category)
                  .AsQueryable()
                  .ToListAsync();

                return questions;
            }
            throw new Exception("Products repo is not set");
        }
        public async Task<Product?> GetSingleProduct(int id)
        {
            if (_context.Products != null)
            {
                Product? question = await _context.Products
                  .Include(q => q.Category)
                  .FirstOrDefaultAsync(u => u.Id == id);
                return question;
            }
            throw new Exception("Products repo is not set");
        }

    }
}
