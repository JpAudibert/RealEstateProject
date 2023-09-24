using Microsoft.EntityFrameworkCore;
using RealEstateBackend.Amenities.Models;
using RealEstateBackend.EF;
using RealEstateBackend.EF.Interfaces;

namespace RealEstateBackend.Amenities.Repository
{
    public class AmenitiesRepository : IRepository<Amenity>
    {
        private readonly RealEstateContext _context;

        public AmenitiesRepository(RealEstateContext context)
        {
            _context = context;
        }

        public async Task Create(Amenity amenity)
        {
            await _context.Amenities.AddAsync(amenity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            _context.Amenities.Where(x => x.Id == id).ExecuteDelete();
            await _context.SaveChangesAsync();
        }

        public async Task<Amenity> Get(Guid id)
        {
            return await _context.Amenities.FindAsync(id) ?? new Amenity();
        }

        public async Task<IEnumerable<Amenity>> GetAll()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task Update(Amenity amenity, Guid id)
        {
            _context.Amenities.Where(x => x.Id == id)
                .ExecuteUpdate(setters => 
                    setters.SetProperty(x => x.Name, amenity.Name));

            await _context.SaveChangesAsync();
        }
    }
}
