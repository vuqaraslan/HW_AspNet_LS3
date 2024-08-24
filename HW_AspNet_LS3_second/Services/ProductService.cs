using HW_AspNet_LS3_second.Entities;
using HW_AspNet_LS3_second.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW_AspNet_LS3_second.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddAsync(Product product)
        {
            await _productRepository.AddAsync(product);
        }

        public async Task DeleteAsync(Product product)
        {
            await _productRepository.DeleteAsync(product);
        }

        public async Task<List<Product>> GetAllByKeyAsync(string key = "")
        {
            return await _productRepository.GetAllAsync(key);
        }

        public async Task UpdateAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<Product> GetByNameAsync(string name)
        {
            return await _productRepository.GetProductByName(name);
        }
    }
}
