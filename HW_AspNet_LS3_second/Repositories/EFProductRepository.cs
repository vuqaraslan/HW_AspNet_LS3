using HW_AspNet_LS3_second.DatabaseContext;
using HW_AspNet_LS3_second.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW_AspNet_LS3_second.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ProductDbContext _productDbContext;

        public EFProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public async Task AddAsync(Product product)
        {
            await _productDbContext.Products.AddAsync(product);
            await _productDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            var pr = _productDbContext.Products.Remove(product);
            await _productDbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync(string key)
        {
            var keyCode = key.ToLower();
            return await _productDbContext.Products.Where(p => p.Name.ToLower().Contains(keyCode)).ToListAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            var result = _productDbContext.Products.Update(product);
            await _productDbContext.SaveChangesAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productDbContext.Products.SingleOrDefaultAsync(p=>p.Id == id);
        }

        public async Task<Product> GetProductByName(string name)
        {
            var byName=name.ToLower();
            return await _productDbContext.Products.SingleOrDefaultAsync(p=>p.Name.ToLower().Contains(byName));
        }
    }
}
