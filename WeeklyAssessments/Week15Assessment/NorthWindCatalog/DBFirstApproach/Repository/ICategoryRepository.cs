using NorthWind.Services.Models;

namespace NorthWind.Services.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
