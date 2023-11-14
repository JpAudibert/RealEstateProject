using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateBackend.Infrastructure.Amenities.Models;
using RealEstateBackend.Infrastructure.EF.Interfaces;
using RealEstateBackend.Infrastructure.RealEstates.Models;
using RealEstateBackend.RealEstates.InputModels;

namespace RealEstateBackend.RealEstates.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RealEstatesController : Controller
    {
        private readonly IRepository<RealEstate> _realEstateRepository;
        private readonly IRepository<Amenity> _amenityRepository;
        private readonly ILogger<RealEstatesController> _logger;

        public RealEstatesController(IRepository<RealEstate> realEstateRepository, IRepository<Amenity> amenityRepository, ILogger<RealEstatesController> logger)
        {
            _realEstateRepository = realEstateRepository;
            _amenityRepository = amenityRepository;
            _logger = logger;
        }

        [HttpGet("v1")]
        public async Task<ActionResult<RealEstate>> GetAllRealEstates()
        {
            _logger.LogInformation("Get All Real Estates Request");
            return Ok(await _realEstateRepository.GetAll());
        }

        [HttpGet("v1/{id}")]
        public async Task<ActionResult<RealEstate>> GetRealEstates(Guid id)
        {
            _logger.LogInformation("Get All Real Estates Request");
            return Ok(await _realEstateRepository.Get(id));
        }

        [HttpPost("v1")]
        public async Task<ActionResult<RealEstate>> Create([FromBody] RealEstateInputModel realEstate)
        {
            _logger.LogInformation("Creating Real Estate: {realEstate}", JsonConvert.SerializeObject(realEstate));

            IEnumerable<Amenity> amenities = await _amenityRepository.Get(realEstate.Amenities);

            RealEstate estate = new()
            {
                IsActive = realEstate.IsActive,
                ComercialType = realEstate.ComercialType,
                Title = realEstate.Title,
                Description = realEstate.Description,
                Address = realEstate.Address,
                Number = realEstate.Number,
                City = realEstate.City,
                State = realEstate.State,
                ZipCode = realEstate.ZipCode,
                SquareFoot = realEstate.SquareFoot,
                PrivateSquareFoot = realEstate.PrivateSquareFoot,
                SellValue = realEstate.SellValue,
                RentValue = realEstate.RentValue,
                Bedrooms = realEstate.Bedrooms,
                Bathrooms = realEstate.Bathrooms,
                Garage = realEstate.Garage,
                RealEstateKindId = realEstate.RealEstateKindId,
                Amenities = amenities.ToList()
            };
            RealEstate created = await _realEstateRepository.Create(estate);

            return Ok(created);
        }

        [HttpPut("v1/{id}")]
        public async Task<ActionResult<RealEstate>> Update(Guid id, [FromBody] RealEstateInputModel realEstate)
        {
            _logger.LogInformation("Updating Real Estate: {realEstate}", JsonConvert.SerializeObject(realEstate));

            IEnumerable<Amenity> amenities = await _amenityRepository.Get(realEstate.Amenities);

            RealEstate estate = new()
            {
                IsActive = realEstate.IsActive,
                ComercialType = realEstate.ComercialType,
                Title = realEstate.Title,
                Description = realEstate.Description,
                Address = realEstate.Address,
                Number = realEstate.Number,
                City = realEstate.City,
                State = realEstate.State,
                ZipCode = realEstate.ZipCode,
                SquareFoot = realEstate.SquareFoot,
                PrivateSquareFoot = realEstate.PrivateSquareFoot,
                SellValue = realEstate.SellValue,
                RentValue = realEstate.RentValue,
                Bedrooms = realEstate.Bedrooms,
                Bathrooms = realEstate.Bathrooms,
                Garage = realEstate.Garage,
                RealEstateKindId = realEstate.RealEstateKindId,
                Amenities = amenities.ToList()
            };
            RealEstate updated = await _realEstateRepository.Update(estate, id);

            return Ok(updated);
        }

        [HttpDelete("v1/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("Deleting Real Estate: {id}", id);

            await _realEstateRepository.Delete(id);

            return NoContent();
        }
    }
}
