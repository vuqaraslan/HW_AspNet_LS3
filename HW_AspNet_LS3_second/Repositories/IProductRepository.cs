using HW_AspNet_LS3_second.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW_AspNet_LS3_second.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(string key);
        Task AddAsync(Product product);
        Task DeleteAsync(Product product);
        Task UpdateAsync(Product product);
        Task<Product> GetByIdAsync(int id);

        Task<Product> GetProductByName(string name);

    }
}
