using APILern.Domain.Entities;
using APILern.Domain.Interface;
using APILern.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace APILern.Infrastructure.Persistance.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductCategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ProductCategory> CreateAsync(ProductCategory category)
        {
            var result = await _dbContext.ProductCategories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _dbContext.ProductCategories.FindAsync(id);
            if (category is null) return;

            _dbContext.ProductCategories.Remove(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductCategory>> GetAlAsync()
        {
            var categories = await _dbContext.ProductCategories.Include(pc => pc.Products).ToListAsync();
            return categories;
        }

        public async Task<ProductCategory> GetByIdAsync(int id)
        {
            var category = await _dbContext.ProductCategories
                .Include(pc => pc.Products)
                .FirstOrDefaultAsync(c => c.Id == id);
            return category;
        }
    }
}