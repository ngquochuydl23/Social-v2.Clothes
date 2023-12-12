using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Social_v2.Clothes.Api.Infrastructure.Entities.Inventories;
using Social_v2.Clothes.Api.Infrastructure.Repository;


namespace Social_v2.Clothes.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class InventoryController : BaseController
  {
    private readonly IMapper _mapper;
    private readonly IRepository<InventoryEntity> _inventoryRepo;
    public InventoryController(
        IMapper mapper,
        IRepository<InventoryEntity> inventoryRepo,
        IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
      _mapper = mapper;
      _inventoryRepo = inventoryRepo;
    }

    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET api/<InventoryController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }

    // POST api/<InventoryController>
    [HttpPost]
    public IActionResult CreateInventory([FromBody] string value)
    {
      return Ok(value);
    }

    // PUT api/<InventoryController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<InventoryController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
