using NorthWind.Services.DTOs;
using NorthWind.Services.Models;

namespace NorthWind.Services.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);
        Task<IEnumerable<CategorySummaryDto>> GetCategorySummariesAsync();

    }
}
