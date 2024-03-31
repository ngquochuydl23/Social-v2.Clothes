using AutoMapper;
using Clothes.Commons.Exceptions;
using Clothes.Commons.Seedworks;
using Clothes.Commons.Settings.JwtSetting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Social_v2.Clothes.Api.Dtos;
using Social_v2.Clothes.Api.Dtos.Users;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using Social_v2.Clothes.Api.Infrastructure.Repository;

namespace Social_v2.Clothes.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IJwtExtension _jwtExtension;
        private readonly IRepository<UserEntity> _userRepo;
        private readonly IEfRepository<UserEntity, long> _userEfRepo;
        private readonly IMapper _mapper;

        public UserController(
            IMapper mapper,
            IRepository<UserEntity> userRepo,
            IEfRepository<UserEntity, long> userEfRepo,
            IHttpContextAccessor httpContextAccessor,
            IJwtExtension jwtExtension) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _userRepo = userRepo;
            _userEfRepo = userEfRepo;
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
            var user = _userEfRepo
                .GetQueryable()
                .FirstOrDefault(x => x.PhoneNumber.Equals(input.PhoneNumber))
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
            user.Avatar = !string.IsNullOrEmpty(value.Avatar) ? value.Avatar : null;
            _userRepo.SaveChanges();

            return Ok(_mapper.Map<UserDto>(user));
        }

        [AllowAnonymous]
        [HttpPut("resetPassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordDto value)
        {
            var user = _userRepo
               .GetQueryable()
               .FirstOrDefault(x => x.Id == 1)
                    ?? throw new AppException("User does not exist");

            user.HashPassword = BCrypt.Net.BCrypt.HashPassword(value.Password);
            _userRepo.SaveChanges();

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpDelete("{id}")]
        public void Delete()
        {

        }
    }
}
