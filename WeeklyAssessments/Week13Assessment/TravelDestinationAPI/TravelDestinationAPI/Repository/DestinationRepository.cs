using Microsoft.EntityFrameworkCore;
using TravelDestinationAPI.Data;
using TravelDestinationAPI.Models;

namespace TravelDestinationAPI.Repository
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly TravelDestinationAPIContext _context;

        public DestinationRepository(TravelDestinationAPIContext context)
        {
            _context = context;
        }
        public async Task<Destination> AddAsync(Destination destination)
        {
            await _context.Destination.AddAsync(destination);
            await _context.SaveChangesAsync();
            return destination;
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.Destination.FindAsync(id);
            if (data == null)
                throw new Exception("Destination not found");
            _context.Destination.Remove(data);
            await _context.SaveChangesAsync();
            
        }


        public async Task<Destination> GetByIdAsync(int id)
        {
            return await _context.Destination.FindAsync(id);
        }

        public async Task<Destination> UpdateAsync(Destination destination)
        {
            _context.Destination.Update(destination);
            await _context.SaveChangesAsync();
            return destination;
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            return await _context.Destination.ToListAsync();
        }

       
    }
}
