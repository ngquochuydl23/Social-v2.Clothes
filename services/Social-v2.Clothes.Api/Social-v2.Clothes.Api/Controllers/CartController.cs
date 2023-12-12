using Microsoft.AspNetCore.Mvc;
using Social_v2.Clothes.Api.Dtos.Cart;

namespace Social_v2.Clothes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCart()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateCart([FromBody] CreateCartDto value)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult EditCart(long id, [FromBody] string value)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCart(long id)
        {
            return Ok();
        }

        [HttpPatch("{id}/increaseQuantity")]
        public IActionResult IncreaseQuantity(long id)
        {
            return Ok();
        }

        [HttpPatch("{id}/decreaseQuantity")]
        public IActionResult DecreaseQuantity(long id)
        {
            return Ok();
        }
    }
}
