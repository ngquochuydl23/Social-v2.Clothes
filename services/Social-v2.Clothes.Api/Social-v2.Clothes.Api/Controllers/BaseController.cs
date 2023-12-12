using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Repository;
using System.Security.Claims;

namespace Social_v2.Clothes.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BaseController: ControllerBase
  {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly HttpContext _httpContext;

    public BaseController(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
      _httpContext = httpContextAccessor.HttpContext;
    }

    protected long Id => long.Parse(_httpContext.User.FindFirstValue("id"));
  }
}
