using AutoMapper;
using Clothes.Commons;
using Clothes.Commons.Exceptions;
using Clothes.Commons.Seedworks;
using Clothes.User.Api.Dtos;
using Clothes.User.Api.Infrastucture.Entities.Users;
using Clothes.User.Api.Infrastucture.EntityValidator;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clothes.User.Api.Controllers
{
    [Authorize]
    [Route("user-api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IEfRepository<UserEntity, string> _userRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(
           IEfRepository<UserEntity, string> userRepo,
           IHttpContextAccessor httpContextAccessor,
           IUnitOfWork unitOfWork,
           IMapper mapper) : base(httpContextAccessor)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("signUp")]
        public IActionResult SignUp([FromBody] SignUpDto signUpDto)
        {
            var user = _mapper.Map<UserEntity>(signUpDto);
            UserValidator validator = new UserValidator();
            ValidationResult results = validator.Validate(user);
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
                user = _userRepo.Insert(new UserEntity()
                {
                    FullName = signUpDto.FullName,
                    Email = signUpDto.Email,
                    PhoneNumber = signUpDto.PhoneNumber,
                    Password = BCrypt.Net.BCrypt.HashPassword(signUpDto.Password),
                    BirthDay = signUpDto.BirthDay,
                    Gender = signUpDto.Gender,
                });
                return Ok(_mapper.Map<UserEntity>(user));

            }
        }
    }
}
