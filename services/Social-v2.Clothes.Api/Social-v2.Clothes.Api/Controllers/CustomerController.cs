using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Social_v2.Clothes.Api.Dtos.Customer;
using Social_v2.Clothes.Api.Infrastructure.Entities.Discounts;
using Social_v2.Clothes.Api.Infrastructure.Entities.StockLocations;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using Social_v2.Clothes.Api.Infrastructure.Exceptions;
using Social_v2.Clothes.Api.Infrastructure.Repository;

namespace Social_v2.Clothes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IRepository<UserEntity> _userRepo;
        public CustomerController(
            IMapper mapper,
            IRepository<UserEntity> userRepo,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _userRepo = userRepo;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _userRepo
                .GetQueryableNoTracking()
                .Where(x => x.Role.Equals(UserConstants.CustomerRole) && !x.IsDeleted)
                .ToList();

            return Ok(_mapper.Map<ICollection<CustomerDto>>(customers));
        }

        [HttpGet("{id}")]
        public IActionResult GetDetailCustomer(long id)
        {
            var customer = _userRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.Role.Equals(UserConstants.CustomerRole) && !x.IsDeleted && x.Id == id)
                    ?? throw new AppException("Customer not found");

            return Ok(_mapper.Map<CustomerDetailDto>(customer));
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] string value)
        {
            return Ok();
        }

    
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
