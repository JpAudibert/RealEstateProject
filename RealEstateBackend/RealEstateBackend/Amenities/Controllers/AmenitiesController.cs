﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateBackend.Amenities.InputModels;
using RealEstateBackend.Infrastructure.Amenities.Models;
using RealEstateBackend.Infrastructure.EF.Interfaces;

namespace RealEstateBackend.Amenities.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AmenitiesController : Controller
    {
        private readonly IRepository<Amenity> _amenitiesRepository;
        private readonly ILogger<AmenitiesController> _logger;

        public AmenitiesController(IRepository<Amenity> amenitiesRepository, ILogger<AmenitiesController> logger)
        {
            _amenitiesRepository = amenitiesRepository;
            _logger = logger;
        }

        [HttpGet("v1")]
        public async Task<IActionResult> GetAllAmenities()
        {
            _logger.LogInformation("Get All Amenities Request");

            return Ok(await _amenitiesRepository.GetAll());
        }

        [HttpGet("v1/{id}")]
        public async Task<IActionResult> GetAmenity(Guid id)
        {
            _logger.LogInformation("Getting amenity: {id}", id);

            return Ok(await _amenitiesRepository.Get(id));
        }

        [HttpPost("v1")]
        public async Task<IActionResult> Create([FromBody] AmenitiesInputModel amenity)
        {
            _logger.LogInformation("Creating amenity: {amenity}", JsonConvert.SerializeObject(amenity));

            Amenity newAmenity = new(amenity.Name);
            Amenity created = await _amenitiesRepository.Create(newAmenity);

            _logger.LogInformation("Amenity created: {created}", JsonConvert.SerializeObject(created));

            return Ok(newAmenity);
        }

        [HttpPut("v1/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AmenitiesInputModel amenity)
        {
            _logger.LogInformation("Updating amenity({id}): {amenity}", id, JsonConvert.SerializeObject(amenity));

            Amenity newAmenity = new(amenity.Name);
            Amenity updated = await _amenitiesRepository.Update(newAmenity, id);

            if (updated is null)
            {
                _logger.LogInformation("There is not an amenity with this ID: {id}", id);
                return NotFound($"There is not an amenity with this ID: {id}");
            }

            _logger.LogInformation("Amenity updated: {amenity}", JsonConvert.SerializeObject(updated));

            return Ok(updated);
        }

        [HttpDelete("v1/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("Deleting amenity({id})", id);

            await _amenitiesRepository.Delete(id);

            _logger.LogInformation("Amenity deleted ({id})", id);

            return NoContent();
        }
    }
}
