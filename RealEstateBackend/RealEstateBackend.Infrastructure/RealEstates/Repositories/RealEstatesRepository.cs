using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RealEstateBackend.Infrastructure.Amenities.Models;
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

        public async Task Delete(Guid id)
        {
            _logger.LogInformation("Deleting Real Estate: {id}", id);

            await _context.RealEstates.Where(x => x.Id == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }

        public async Task<RealEstate> Get(Guid id)
        {
            _logger.LogInformation("Getting Real Estate: {id}", id);

            return await _context.RealEstates.FindAsync(id) ?? new RealEstate();
        }

        public Task<IEnumerable<RealEstate>> Get(ICollection<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RealEstate>> GetAll()
        {
            _logger.LogInformation("Getting all Real Estates");

            return await _context.RealEstates.Include(x => x.Amenities).ToListAsync();
        }

        public async Task<RealEstate> Update(RealEstate realEstate, Guid id)
        {
            _logger.LogInformation("Updating Real Estate: {id}", id);

            _context.RealEstates.Where(x => x.Id == id)
                .ExecuteUpdate(setters => setters
                    .SetProperty(x => x.IsActive, realEstate.IsActive)
                    .SetProperty(x => x.ComercialType, realEstate.ComercialType)
                    .SetProperty(x => x.Title, realEstate.Title)
                    .SetProperty(x => x.Description, realEstate.Description)
                    .SetProperty(x => x.Address, realEstate.Address)
                    .SetProperty(x => x.Number, realEstate.Number)
                    .SetProperty(x => x.City, realEstate.City)
                    .SetProperty(x => x.State, realEstate.State)
                    .SetProperty(x => x.ZipCode, realEstate.ZipCode)
                    .SetProperty(x => x.SquareFoot, realEstate.SquareFoot)
                    .SetProperty(x => x.PrivateSquareFoot, realEstate.PrivateSquareFoot)
                    .SetProperty(x => x.SellValue, realEstate.SellValue)
                    .SetProperty(x => x.RentValue, realEstate.RentValue)
                    .SetProperty(x => x.Bedrooms, realEstate.Bedrooms)
                    .SetProperty(x => x.Bathrooms, realEstate.Bathrooms)
                    .SetProperty(x => x.Garage, realEstate.Garage)
                    .SetProperty(x => x.RealEstateKindId, realEstate.RealEstateKindId)
                    );

            RealEstate? updatedRealEstate = await _context.RealEstates.FindAsync(id);

            if (updatedRealEstate != null)
            {
                updatedRealEstate.Amenities.Clear();
                await _context.SaveChangesAsync();

                //updatedRealEstate.Amenities.AddRange(realEstate.Amenities);
            }

            await _context.SaveChangesAsync();

            return updatedRealEstate;
        }
    }
}
