using Clothes.Commons.Wrappers;
using Clothes.Order.Api.Dtos;
using Clothes.Order.Api.Filters;
using Microsoft.AspNetCore.Mvc;


namespace Clothes.Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet("/store/orders")]
        public IActionResult GetStoreOrders([FromQuery] OrderListFilter filter)
        {
            return Ok(new PagedResponse<OrderDto>());
        }

        [HttpGet("/store/orders/{orderId}")]
        public IActionResult GetStoreOrder(string orderId)
        {
            return Ok(new OrderDto
            {
                Id = Guid.NewGuid().ToString(),

            });
        }

        [HttpGet("/admin/orders")]
        public IActionResult GetAdminOrders([FromQuery] OrderListFilter filter)
        {
            return Ok(new PagedResponse<OrderDto>());
        }


        [HttpGet("/admin/orders/{orderId}")]
        public IActionResult GetAdminOrder(string orderId)
        {
            return Ok(new OrderDto
            {
                Id = Guid.NewGuid().ToString(),
                
            });
        }


        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok();
        }

        [HttpPost("/admin/orders/{orderId}/archive")]
        public IActionResult AdminArchiveOrder([FromBody] string value)
        {
            return Ok();
        }

        [HttpPost("/admin/orders/{orderId}/cancel")]
        public IActionResult AdminCancelOrder([FromBody] string value)
        {
            return Ok();
        }

        [HttpPut("{orderId}")]
        public IActionResult EditOrder(string orderId, [FromBody] string value)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok();
        }
    }
}
