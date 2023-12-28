using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Social_v2.Clothes.Api.Dtos;
using Social_v2.Clothes.Api.Dtos.Users;
using Social_v2.Clothes.Api.Extensions.JwtHelpers;
using Social_v2.Clothes.Api.Infrastructure;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using Social_v2.Clothes.Api.Infrastructure.Exceptions;
using Social_v2.Clothes.Api.Infrastructure.Repository;
using Social_v2.Clothes.Api.Migrations;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;

namespace Social_v2.Clothes.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IJwtExtension _jwtExtension;
        private readonly IRepository<UserEntity> _userRepo;
        private readonly IMapper _mapper;

        public UserController(
            IMapper mapper,
            IRepository<UserEntity> userRepo,
            IHttpContextAccessor httpContextAccessor,
            IJwtExtension jwtExtension) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _userRepo = userRepo;
            _jwtExtension = jwtExtension;
        }

        [HttpGet("persistLogin")]
        public IActionResult PersistLogin()
        {
            var user = _userRepo.GetQueryableNoTracking()
               .FirstOrDefault(x => x.Id == Id)
               ?? throw new AppException("User does not exist");
            return Ok(_mapper.Map<UserDto>(user));
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto input)
        {
            var user = _userRepo
                .GetQueryable()
                .FirstOrDefault(x => x.PhoneNumber == input.PhoneNumber)
                ?? throw new AppException("User does not exist");

            if (!BCrypt.Net.BCrypt.Verify(input.Password, user.HashPassword))
                throw new AppException("Password is incorrect");

            user.LastLogin = DateTime.UtcNow;
            _userRepo.SaveChanges();

            var token = _jwtExtension.GenerateToken(user.Id, user.Role);
            return Ok(new LoginResponseDto(token, _mapper.Map<UserDto>(user)));
        }

        [AllowAnonymous]
        [HttpPost("signUp")]
        public IActionResult SignUp([FromBody] SignUpRequestDto input)
        {
            var user = _userRepo.Insert(new UserEntity()
            {
                FullName = input.FullName,
                Birthday = input.Birthday,
                Gender = input.Gender,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                HashPassword = BCrypt.Net.BCrypt.HashPassword(input.Password),
            });

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPut("updateInfo")]
        public IActionResult UpdateInfo([FromBody] UpdateInfoDto value)
        {
            var user = _userRepo
               .GetQueryable()
               .FirstOrDefault(x => x.Id == Id)
                    ?? throw new AppException("User does not exist");

            user.FullName = value.FullName;
            user.Email = value.Email;
            user.PhoneNumber = value.PhoneNumber;
            user.Gender = value.Gender;
            user.Birthday = value.Birthday;
            user.LastUpdate = DateTime.Now;

            _userRepo.SaveChanges();

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpDelete("{id}")]
        public void Delete()
        {

        }
    }
}
