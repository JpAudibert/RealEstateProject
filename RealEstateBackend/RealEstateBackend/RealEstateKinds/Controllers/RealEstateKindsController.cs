using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateBackend.EF.Interfaces;
using RealEstateBackend.RealEstateTypes.InputModels;
using RealEstateBackend.RealEstateTypes.Models;

namespace RealEstateBackend.RealEstateKinds.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RealEstateKindsController : ControllerBase
    {
        private readonly IRepository<RealEstateKind> _kindsRepository;
        private readonly ILogger<RealEstateKindsController> _logger;

        public RealEstateKindsController(IRepository<RealEstateKind> kindsRepository, ILogger<RealEstateKindsController> logger)
        {
            _kindsRepository = kindsRepository;
            _logger = logger;
        }

        [HttpGet("v1")]
        public async Task<IActionResult> GetAllKinds()
        {
            _logger.LogInformation("Get All Real Estate Kinds Request");

            return Ok(await _kindsRepository.GetAll());
        }

        [HttpGet("v1/{id}")]
        public async Task<IActionResult> GetKind(Guid id)
        {
            _logger.LogInformation("Getting Real Estate Kind: {id}", id);

            RealEstateKind kind = await _kindsRepository.Get(id);

            if (kind.Id == Guid.Empty)
            {
                _logger.LogInformation("There is not a real estate kind with this ID: {id}", id);
                return NotFound($"There is not a real estate kind with this ID: {id}");
            }

            return Ok();
        }

        [HttpPost("v1")]
        public async Task<IActionResult> Create([FromBody] RealEstateKindsInputModel realEstateKind)
        {
            _logger.LogInformation("Creating Real Estate Kind: {realEstateKind}", JsonConvert.SerializeObject(realEstateKind));

            RealEstateKind newRealEstateKind = new(realEstateKind.Name);
            RealEstateKind created = await _kindsRepository.Create(newRealEstateKind);

            _logger.LogInformation("Real Estate Kind created: {created}", JsonConvert.SerializeObject(created));

            return Ok(newRealEstateKind);
        }

        [HttpPut("v1/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] RealEstateKindsInputModel realEstateKind)
        {
            _logger.LogInformation("Updating Real Estate Kind({id}): {realEstateKind}", id, JsonConvert.SerializeObject(realEstateKind));

            RealEstateKind newRealEstateKind = new(realEstateKind.Name);
            RealEstateKind updated = await _kindsRepository.Update(newRealEstateKind, id);

            if (updated is null)
            {
                _logger.LogInformation("There is not a real estate kind with this ID: {id}", id);
                return NotFound($"There is not a real estate kind with this ID: {id}");
            }

            _logger.LogInformation("Real Estate Kind updated: {realEstateKind}", JsonConvert.SerializeObject(updated));

            return Ok(updated);
        }

        [HttpDelete("v1/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("Deleting Real Estate Kind({id})", id);

            await _kindsRepository.Delete(id);

            _logger.LogInformation("Real Estate Kind deleted ({id})", id);

            return NoContent();
        }

        [HttpPost("v1/createmany")]
        public async Task<IActionResult> Populate()
        {
            List<RealEstateKind> list = new()
            {
                new RealEstateKind("Terreno"),
                new RealEstateKind("Casa"),
                new RealEstateKind("Apartamento"),
                new RealEstateKind("Área Rural"),
                new RealEstateKind("Sala Comercial")
            };

            _logger.LogDebug("Creating many Real Estate Kinds");

            await _kindsRepository.CreateMany(list);

            return (Ok(list));
        }
    }
}
