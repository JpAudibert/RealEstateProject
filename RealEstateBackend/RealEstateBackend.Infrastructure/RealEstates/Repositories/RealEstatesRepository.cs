using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RealEstateBackend.Infrastructure.Amenities.Repositories;
using RealEstateBackend.Infrastructure.EF;
using RealEstateBackend.Infrastructure.EF.Interfaces;
using RealEstateBackend.Infrastructure.RealEstates.Models;

namespace RealEstateBackend.Infrastructure.RealEstates.Repositories
{
    public class RealEstatesRepository : IRepository<RealEstate>
    {
        private readonly RealEstateContext _context;
        private readonly ILogger<AmenitiesRepository> _logger;

        public RealEstatesRepository(RealEstateContext context, ILogger<AmenitiesRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<RealEstate> Create(RealEstate realEstate)
        {
            _logger.LogInformation("Received amenity: {amenity}", JsonConvert.SerializeObject(realEstate));

            await _context.RealEstates.AddAsync(realEstate);
            await _context.SaveChangesAsync();
            return realEstate;
        }

        public Task CreateMany(IEnumerable<RealEstate> entities)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<RealEstate> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RealEstate>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<RealEstate> Update(RealEstate type, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
