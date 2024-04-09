using AutoMapper;
using Clothes.Commons;
using Clothes.Commons.Exceptions;
using Clothes.Commons.Seedworks;
using Clothes.User.Api.Dtos;
using Clothes.User.Api.Infrastucture.Entities.ShippingAddresses;
using Clothes.User.Api.Infrastucture.EntityValidator;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Clothes.User.Api.Controllers
{
    [Authorize]
    [Route("shippingAddress-api/[controller]")]
    [ApiController]
    public class ShippingAddressController : BaseController
    {
        private readonly IEfRepository<ShippingAddressEntity, long> _shippingAddressRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //private readonly IValidator<ShippingAddressEntity,ShippingAddressValidator> _validator;

        public ShippingAddressController(IEfRepository<ShippingAddressEntity, long> shippingAddressRepo, IHttpContextAccessor httpContextAccessor,
           IUnitOfWork unitOfWork,
           //IValidator<ShippingAddressEntity, ShippingAddressValidator> validator,
           IMapper mapper) : base(httpContextAccessor)
        {
            _shippingAddressRepo = shippingAddressRepo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_validator = validator;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetShippingAddresses()
        {
            var address = _shippingAddressRepo.GetQueryableNoTracking().Where(x => !x.IsDeleted&&x.UserId==1).OrderBy(x => x.IsDefaultAddress).OrderBy(x => x.CreatedAt).ToList();
            return Ok(_mapper.Map<IEnumerable<ShippingAddressEntity>>(address));
        }

        [HttpGet("id")]
        public IActionResult GetShippingAddress(long id)
        {
            var address = _shippingAddressRepo.GetQueryable().FirstOrDefault(x => x.Id == id && !x.IsDeleted && x.UserId == Id) ?? throw new AppException("Address is null"); ;
            return Ok(_mapper.Map<ShippingAddressEntity>(address));
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddNewAddress([FromBody] CreateUpdateAddressDto input)
        {
            var address = _mapper.Map<ShippingAddressEntity>(input);
            address.UserId = 1;
            ShippingAddressValidator validator = new ShippingAddressValidator();
            ValidationResult results = validator.Validate(address);
            //var resultIsValid=_validator.Validate(address);
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    throw new AppException("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
                return BadRequest();
            }
            else
            {
                if (input.IsDefaultAddress)
                {
                    var oldDefault = _shippingAddressRepo
                        .GetQueryable()
                        .FirstOrDefault(x => x.IsDefaultAddress && x.UserId == Id && !x.IsDeleted);

                    if (oldDefault != null)
                    {
                        oldDefault.IsDefaultAddress = false;
                        _shippingAddressRepo.Update(oldDefault.Id, oldDefault);
                    }
                }
                return Ok(_mapper.Map<ShippingAddressEntity>(_shippingAddressRepo.Insert(address)));
            }
           
        }

        [HttpPut("{id}")]
        public IActionResult EditAddress(long id, [FromBody] CreateUpdateAddressDto input)
        {
            var address = _shippingAddressRepo
                   .GetQueryable()
                   .FirstOrDefault(x => x.Id == id && x.UserId == Id && !x.IsDeleted)
                   ?? throw new AppException("Address is null");

            address.Name = input.Name;
            address.PhoneNumber = input.PhoneNumber;
            address.AddressDetail = input.AddressDetail;
            address.ProvinceOrCity = input.ProvinceOrCity;
            address.District = input.District;
            address.WardOrCommune = input.WardOrCommune;
            address.IsDefaultAddress = input.IsDefaultAddress;

            _shippingAddressRepo.Update(address.Id, address);

            return Ok(_mapper.Map<CreateUpdateAddressDto>(address));
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _shippingAddressRepo.Delete(id);
            return Ok();
        }
    }
}
