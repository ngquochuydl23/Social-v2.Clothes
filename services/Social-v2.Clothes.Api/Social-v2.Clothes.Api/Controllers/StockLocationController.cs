using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Social_v2.Clothes.Api.Dtos.StockLocation;
using Social_v2.Clothes.Api.Infrastructure.Entities.Stores;
using Social_v2.Clothes.Api.Infrastructure.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Social_v2.Clothes.Api.Controllers
{

    [Authorize]
    [Route ("api/[controller]")]
    [ApiController]
    public class StockLocationController : BaseController
    {
        private readonly IRepository<StockLocationEntity> _locationRepo;
        private readonly IMapper _mapper;

        public StockLocationController(
            IRepository<StockLocationEntity> locationRepo,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper) : base(httpContextAccessor)
        {
            this._locationRepo = locationRepo;
            this._mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var locations = _locationRepo
              .GetQueryableNoTracking()
              .Where(x => !x.IsDeleted)
              .ToList();

            var mappedLocations = _mapper.Map<List<AdminStockLocationDto>>(locations);

            return Ok(mappedLocations);
        }

        // GET api/<StockLocationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StockLocationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StockLocationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StockLocationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
