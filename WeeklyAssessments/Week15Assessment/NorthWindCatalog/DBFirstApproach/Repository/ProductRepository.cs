using Microsoft.EntityFrameworkCore;
using NorthWind.Services.Data;
using NorthWind.Services.DTOs;
using NorthWind.Services.Models;

namespace NorthWind.Services.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly NorthWindContext _context;

        public ProductRepository(NorthWindContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<CategorySummaryDto>> GetCategorySummariesAsync()
        {
            return await _context.Categories
                .Select(c => new CategorySummaryDto
                {
                    CategoryName = c.CategoryName,
                    ProductCount = c.Products.Count(),                   
                    AvgPrice = c.Products.Select(p => p.UnitPrice).Average() ?? 0.00m,
                    MostExpensiveProduct = c.Products
                        .OrderByDescending(p => p.UnitPrice)
                        .Select(p => p.ProductName)
                        .FirstOrDefault()
                }).ToListAsync();
        }
    }

}
