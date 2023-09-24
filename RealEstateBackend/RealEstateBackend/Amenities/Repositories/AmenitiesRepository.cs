using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RealEstateBackend.Amenities.Models;
using RealEstateBackend.EF;
using RealEstateBackend.EF.Interfaces;

namespace RealEstateBackend.Amenities.Repository
{
    public class AmenitiesRepository : IRepository<Amenity>
    {
        private readonly RealEstateContext _context;
        private readonly ILogger<AmenitiesRepository> _logger;

        public AmenitiesRepository(RealEstateContext context, ILogger<AmenitiesRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Amenity> Create(Amenity amenity)
        {
            _logger.LogInformation("Received amenity: {amenity}", JsonConvert.SerializeObject(amenity));

            await _context.Amenities.AddAsync(amenity);
            await _context.SaveChangesAsync();

            return amenity;
        }

        public async Task CreateMany(IEnumerable<Amenity> amenities)
        {
            _logger.LogInformation("Creating amenities: {amenity}", JsonConvert.SerializeObject(amenities));

            await _context.Amenities.AddRangeAsync(amenities);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            _logger.LogInformation("Deleting amenity: {id}", id);

            _context.Amenities.Where(x => x.Id == id).ExecuteDelete();
            await _context.SaveChangesAsync();
        }

        public async Task<Amenity> Get(Guid id)
        {
            _logger.LogInformation("Getting amenity: {id}", id);

            return await _context.Amenities.FindAsync(id) ?? new Amenity();
        }

        public async Task<IEnumerable<Amenity>> GetAll()
        {
            _logger.LogInformation("Retrieving all amenities");

            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenity> Update(Amenity amenity, Guid id)
        {
            _logger.LogInformation("Updating amenity ({id}): {amenity}", id, amenity);

            _context.Amenities.Where(x => x.Id == id)
                .ExecuteUpdate(setters => 
                    setters.SetProperty(x => x.Name, amenity.Name));

            Amenity? updatedAmenity = await _context.Amenities.FindAsync(id);

            await _context.SaveChangesAsync();

            return updatedAmenity!;
        }
    }
}
