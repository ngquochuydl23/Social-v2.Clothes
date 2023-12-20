using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Dtos.Collection;
using Social_v2.Clothes.Api.Infrastructure.Entities.Collections;
using Social_v2.Clothes.Api.Infrastructure.Exceptions;
using Social_v2.Clothes.Api.Infrastructure.Repository;


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
        public IActionResult GetCollections()
        {
            var collections = _collectionRepo
                .GetQueryableNoTracking()
                .Where(x => !x.IsDeleted)
                .ToList();

            return Ok(_mapper.Map<ICollection<CollectionDto>>(collections));
        }

        [HttpGet("{id}")]
        public IActionResult GetCollection(string id)
        {
            var collection = _collectionRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.Id.Equals(id) && !x.IsDeleted)
                    ?? throw new AppException("Collection does not exist");

            return Ok(_mapper.Map<CollectionDto>(collection));
        }

        [HttpPost]
        public IActionResult CreateCollection([FromBody] CreateUpdateCollectionDto value)
        {
            var collection = _collectionRepo.Insert(new CollectionEntity(value.Title, value.Handle));
            return Ok(_mapper.Map<CollectionDto>(collection));
        }

        [HttpPut("{id}")]
        public IActionResult EditCollection(string id, [FromBody] CreateUpdateCollectionDto value)
        {

            var collection = _collectionRepo
                .GetQueryable()
                .FirstOrDefault(x => x.Id.Equals(id) && !x.IsDeleted)
                    ?? throw new AppException("Collection does not exist");

            collection.Title = value.Title;
            collection.Handle = value.Handle;

            _collectionRepo.SaveChanges();
            return Ok(_mapper.Map<CollectionDto>(collection));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var collection = _collectionRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.Id.Equals(id) && !x.IsDeleted)
                    ?? throw new AppException("Collection does not exist");

            _collectionRepo.Delete(collection);

            return Ok();
        }
    }
}
