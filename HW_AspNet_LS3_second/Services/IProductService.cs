using HW_AspNet_LS3_second.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW_AspNet_LS3_second.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllByKeyAsync(string key = "");
        Task AddAsync(Product product);
        Task DeleteAsync(Product product);
        Task UpdateAsync(Product product);
        Task<Product> GetByIdAsync(int id);

        Task<Product> GetByNameAsync(string name);
    }
}
