using Clothes.Commons.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Commons
{
    public class BaseController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpContext _httpContext;

        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor 
                ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _httpContext = httpContextAccessor.HttpContext;
        }


        public override OkObjectResult Ok([ActionResultObjectValue] object value)
        {
            if (value.GetType().Equals(typeof(PagedResponse<>)))
            {
                var response = (PagedResponse<object>) value;
                return base.Ok(new
                {
                    Result = response.Result,
                    Offset = response.Offset,
                    Limit = response.Limit,
                    Total = response.Total,
                    StatusCode = StatusCodes.Status200OK
                });
            }

            return base.Ok(new
            {
                Result = value,
                StatusCode = StatusCodes.Status200OK
            });
        }


        protected long Id => long.Parse(_httpContext.User.FindFirstValue("id"));
    }
}
