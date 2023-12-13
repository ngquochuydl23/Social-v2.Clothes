using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Social_v2.Clothes.Api.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class AdminDiscountController : ControllerBase
    {
        // GET: api/<DiscountController>
        [HttpGet]
        [Route("api/admin/[controller]")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DiscountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DiscountController>
        [HttpPost]
        public void CreateDiscount([FromBody] string value)
        {
        }

        // PUT api/<DiscountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DiscountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
