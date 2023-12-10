using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Social_v2.Clothes.Api.Dtos;
using Social_v2.Clothes.Api.Extensions.JwtHelpers;
using Social_v2.Clothes.Api.Infrastructure;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using Social_v2.Clothes.Api.Infrastructure.Exceptions;
using Social_v2.Clothes.Api.Infrastructure.Repository;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;

namespace Social_v2.Clothes.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtExtension _jwtExtension;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpContext _httpContext;
        private readonly IRepository<UserEntity> _userRepo;
        private readonly IMapper _mapper;

        private long Id => long.Parse(_httpContext.User.FindFirstValue("id"));

        public UserController(
            IMapper mapper,
            IRepository<UserEntity> userRepo,
            IHttpContextAccessor httpContextAccessor,
            IJwtExtension jwtExtension)
        {
            _contextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _httpContext = httpContextAccessor.HttpContext;
            _mapper = mapper;
            _userRepo = userRepo;
            _jwtExtension = jwtExtension;
        }

        [HttpGet("persistLogin")]
        public IActionResult PersistLogin()
        {

            return Ok(Id);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto input)
        {
            var user = _userRepo.GetQueryableNoTracking()
                .FirstOrDefault(x => x.PhoneNumber == input.PhoneNumber)
                ?? throw new AppException("User does not exist");

            if (!BCrypt.Net.BCrypt.Verify(input.Password, user.HashPassword))
                throw new AppException("Password is incorrect");

            var token = _jwtExtension.GenerateToken(user.Id, user.Role);
            return Ok(new LoginResponseDto(token, user.Id));
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

        [HttpDelete("{id}")]
        public void Delete()
        {

        }
    }
}
