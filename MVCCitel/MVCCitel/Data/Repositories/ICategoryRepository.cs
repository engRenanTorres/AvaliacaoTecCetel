using MVCCitel.Models.Domain;

namespace MVCCitel.Data.Repositories
{
    public interface ICategoryRepository
    {
        public Task<bool> SaveChanges();
        public void AddEntity<T>(T entity);
        public void RemoveEntity<T>(T entity);
        public Task<IEnumerable<Category?>> GetAllCategories();
        public Task<Category?> GetSingleCategory(int id);
        public Task<Category?> GetSingleCategoryByName(string email);
    }
}
