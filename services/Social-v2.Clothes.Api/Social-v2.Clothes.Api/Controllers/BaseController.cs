using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Repository;
using System.Security.Claims;

namespace Social_v2.Clothes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpContext _httpContext;

        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _httpContext = httpContextAccessor.HttpContext;
        }


        public override OkObjectResult Ok([ActionResultObjectValue] object value)
        {
            return base.Ok(new
            {

                Result = value,
                StatusCode = StatusCodes.Status200OK
            });
        }

        //public OkObjectResult OkAsCollection([ActionResultObjectValue] object value, int offset = 0, int limit = 0, int total = 0)
        //{
        //    return base.Ok(new
        //    {
        //        Result = value,
        //        Offset = offset,
        //        Limit = limit,
        //        Total = total,
        //        StatusCode = StatusCodes.Status200OK
        //    });
        //}

        protected long Id => long.Parse(_httpContext.User.FindFirstValue("id"));
    }
}
