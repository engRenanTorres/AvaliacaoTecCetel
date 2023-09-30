using MVCCitel.Models.Domain;

namespace MVCCitel.Data.Repositories
{
    public interface IProductRepository
    {
        public Task<bool> SaveChanges();
        public void AddEntity<T>(T entity);
        public void RemoveEntity<T>(T entity);
        public Task<IEnumerable<Product?>> GetAllProducts();
        public Task<Product?> GetSingleProduct(int id);
    }
}
