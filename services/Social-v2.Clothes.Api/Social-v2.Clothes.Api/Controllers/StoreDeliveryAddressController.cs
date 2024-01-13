using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Social_v2.Clothes.Api.Dtos.DeliveryAddress;
using Social_v2.Clothes.Api.Extensions.JwtHelpers;
using Social_v2.Clothes.Api.Infrastructure.Entities.DeliveryAddresses;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using Social_v2.Clothes.Api.Infrastructure.Exceptions;
using Social_v2.Clothes.Api.Infrastructure.Repository;
using System.Security.Claims;


namespace Social_v2.Clothes.Api.Controllers
{
    [Authorize]
    [Route("api/store/DeliveryAddress")]
    [ApiController]
    public class StoreDeliveryAddressController : BaseController
    {
        private readonly IRepository<DeliveryAddressEntity> _deliverAddressRepo;
        private readonly IMapper _mapper;

        public StoreDeliveryAddressController(
            IMapper mapper,
            IRepository<DeliveryAddressEntity> deliverAddressRepo,
            IHttpContextAccessor httpContextAccessor): base(httpContextAccessor)
        {
            _mapper = mapper;
            _deliverAddressRepo = deliverAddressRepo;
        }

        [HttpGet]
        public IActionResult GetAddresses()
        {
            var addresses = _deliverAddressRepo
                .GetQueryableNoTracking()
                .Where(x => x.UserId == Id && !x.IsDeleted)
                .OrderBy(x => x.IsDefault)
                .OrderBy(x => x.CreateAt)
                .ToList();

            return Ok(_mapper.Map<IEnumerable<DeliveryAddressDto>>(addresses));
        }

        [HttpGet("{id}")]
        public IActionResult GetAddressById(long id)
        {
            var address = _deliverAddressRepo
                    .GetQueryable()
                    .FirstOrDefault(x => x.Id == id && x.UserId == Id && !x.IsDeleted)
                    ?? throw new AppException("Address is null");

            return Ok(_mapper.Map<DeliveryAddressDto>(address));
        }

        [HttpPost]
        public IActionResult AddNewAddress([FromBody] CreateUpdateAddressDto input)
        {
            var address = _mapper.Map<DeliveryAddressEntity>(input);
            address.UserId = Id;

            if (input.IsDefault)
            {
                var oldDefault = _deliverAddressRepo
                    .GetQueryable()
                    .FirstOrDefault(x => x.IsDefault && x.UserId == Id && !x.IsDeleted);

                if (oldDefault != null)
                {
                    oldDefault.IsDefault = false;
                    _deliverAddressRepo.Update(oldDefault.Id, oldDefault);
                }
            }

            address = _deliverAddressRepo.Insert(address);
            return Ok(_mapper.Map<DeliveryAddressDto>(address));
        }

        [HttpPut("{id}")]
        public IActionResult EditAddress(long id, [FromBody] CreateUpdateAddressDto input)
        {
            var address = _deliverAddressRepo
                   .GetQueryable()
                   .FirstOrDefault(x => x.Id == id && x.UserId == Id && !x.IsDeleted)
                   ?? throw new AppException("Address is null");

            address.Name = input.Name;
            address.PhoneNumber = input.PhoneNumber;
            address.DetailAddress = input.DetailAddress;
            address.ProvinceOrCity = input.ProvinceOrCity;
            address.District = input.District;
            address.WardOrCommune = input.WardOrCommune;
            address.IsDefault = input.IsDefault;

            _deliverAddressRepo.Update(address.Id, address);

            return Ok(_mapper.Map<DeliveryAddressDto>(address));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _deliverAddressRepo.Delete(id);
            return Ok();
        }
    }
}
