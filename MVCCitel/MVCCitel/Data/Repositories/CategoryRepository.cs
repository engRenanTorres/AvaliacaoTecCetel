using Microsoft.EntityFrameworkCore;
using MVCCitel.Models.Domain;

namespace MVCCitel.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContextEF _context;
        public CategoryRepository(DataContextEF context)
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

        public async Task<IEnumerable<Category?>> GetAllCategories()
        {
            if (_context.Categories != null)
            {
                IEnumerable<Category?> categories = await _context.Categories.Include(c => c.Products).ToListAsync();

                return categories;
            }
            throw new Exception("Categories repo is not set");
        }
        public async Task<Category?> GetSingleCategory(int id)
        {
            if (_context.Categories != null)
            {
                Category? category = await _context.Categories.SingleOrDefaultAsync(u => u.Id == id);
                return category;
            }
            throw new Exception("Categories repo is not set");
        }
        public async Task<Category?> GetSingleCategoryByName(string name)
        {
            if (_context.Categories != null)
            {
                Category? category = await _context.Categories.SingleOrDefaultAsync(u => u.Name == name);
                return category;
            }
            throw new Exception("Categories repo is not set");
        }
    }
}
