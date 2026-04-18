using Microsoft.EntityFrameworkCore;
using NorthWind.Services.Data;
using NorthWind.Services.Models;

namespace NorthWind.Services.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NorthWindContext _context;
        public CategoryRepository(NorthWindContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
