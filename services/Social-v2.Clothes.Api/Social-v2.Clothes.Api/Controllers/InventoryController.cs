using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Social_v2.Clothes.Api.Infrastructure.Repository;


namespace Social_v2.Clothes.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class InventoryController : BaseController
  {
    private readonly IMapper _mapper;

    public InventoryController(
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
      _mapper = mapper;
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
    public void Post([FromBody] string value)
    {
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
