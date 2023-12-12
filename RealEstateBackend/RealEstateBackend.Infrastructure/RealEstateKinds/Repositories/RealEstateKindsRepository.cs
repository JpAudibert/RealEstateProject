using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RealEstateBackend.Infrastructure.EF;
using RealEstateBackend.Infrastructure.EF.Interfaces;
using RealEstateBackend.Infrastructure.RealEstateKinds.Models;

namespace RealEstateBackend.Infrastructure.RealEstateKinds.Repositories
{
    public class RealEstateKindsRepository : IRepository<RealEstateKind>
    {
        private readonly RealEstateContext _context;
        private readonly ILogger<RealEstateKindsRepository> _logger;

        public RealEstateKindsRepository(RealEstateContext context, ILogger<RealEstateKindsRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<RealEstateKind> Create(RealEstateKind realEstateKind)
        {
            _logger.LogInformation("Received Real Estate Kind: {realEstateKind}", JsonConvert.SerializeObject(realEstateKind));

            await _context.RealEstateKinds.AddAsync(realEstateKind);
            await _context.SaveChangesAsync();

            return realEstateKind;
        }

        public async Task CreateMany(IEnumerable<RealEstateKind> realEstateKinds)
        {
            _logger.LogInformation("Creating real estate kinds: {kinds}", JsonConvert.SerializeObject(realEstateKinds));

            await _context.RealEstateKinds.AddRangeAsync(realEstateKinds);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            _logger.LogInformation("Deleting real estate kind: {id}", id);

            _context.RealEstateKinds.Where(x => x.Id == id).ExecuteDelete();
            await _context.SaveChangesAsync();
        }

        public async Task<RealEstateKind> Get(Guid id)
        {
            _logger.LogInformation("Getting real estate kind: {id}", id);

            return await _context.RealEstateKinds.FindAsync(id) ?? new RealEstateKind();
        }

        public Task<IEnumerable<RealEstateKind>> Get(ICollection<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RealEstateKind>> GetAll()
        {
            _logger.LogInformation("Retrieving all real estate kinds");

            return await _context.RealEstateKinds.ToListAsync();
        }

        public async Task<RealEstateKind> Update(RealEstateKind kind, Guid id)
        {
            _logger.LogInformation("Updating real estate kind ({id}): {kind}", id, kind);

            _context.RealEstateKinds.Where(x => x.Id == id)
                .ExecuteUpdate(setters =>
                    setters.SetProperty(x => x.Name, kind.Name));

            RealEstateKind? updatedRealEstateKind = await _context.RealEstateKinds.FindAsync(id);

            await _context.SaveChangesAsync();

            return updatedRealEstateKind!;
        }
    }
}
