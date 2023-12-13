using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Social_v2.Clothes.Api.Dtos.Collection;
using Social_v2.Clothes.Api.Infrastructure.Entities.Collections;
using Social_v2.Clothes.Api.Infrastructure.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Social_v2.Clothes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : BaseController
    {
        private readonly IRepository<CollectionEntity> _collectionRepo;
        private readonly IMapper _mapper;

        public CollectionController(
            IMapper mapper,
            IRepository<CollectionEntity> collectionRepo,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _collectionRepo = collectionRepo;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public IActionResult CreateCollection([FromBody] CreateUpdateCollectionDto value)
        {
            var collection = _collectionRepo.Insert(new CollectionEntity(value.Title, value.Handle));
            return Ok(_mapper.Map<CollectionDto>(collection));
        }

        [HttpPut("{id}")]
        public IActionResult EditCollection(int id, [FromBody] CreateUpdateCollectionDto value)
        {
            return Ok();
        }

       [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
