using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Social_v2.Clothes.Api.Dtos.Invites;
using Social_v2.Clothes.Api.Extensions.EmailSender;
using Social_v2.Clothes.Api.Extensions.JwtHelpers;
using Social_v2.Clothes.Api.Infrastructure.Entities.Categories;
using Social_v2.Clothes.Api.Infrastructure.Entities.Invites;
using Social_v2.Clothes.Api.Infrastructure.Exceptions;
using Social_v2.Clothes.Api.Infrastructure.Repository;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using Social_v2.Clothes.Api.Infrastructure.Entities.EmployeeInvitations;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace Social_v2.Clothes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly IEmailSender _emailSender;
        private readonly IJwtExtension _jwtExtension;
        private readonly IRepository<EmployeeInvitationEntity> _employeeInvitationRepo;
        private readonly IRepository<UserEntity> _userRepo;
        private readonly IMapper _mapper;

        public EmployeeController(
            IMapper mapper,
            IRepository<UserEntity> userRepo,
            IEmailSender emailSender,
            IRepository<EmployeeInvitationEntity> employeeInvitationRepo,
            IJwtExtension jwtExtension,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _userRepo = userRepo;
            _emailSender = emailSender;
            _jwtExtension = jwtExtension;
            _employeeInvitationRepo = employeeInvitationRepo;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetInvitations(
            [FromQuery] string? status,
            [FromQuery] string? role)
        {
            var employees = _userRepo
                .GetQueryableNoTracking()
                .Where(x => !x.IsDeleted)
                .Where(x => !x.Role.Equals(UserConstants.CustomerRole))
                .Where(x => !string.IsNullOrEmpty(status) ? x.EmployeeStatus.Equals(status) : true)
                .Where(x => !string.IsNullOrEmpty(role) ? x.Role.Equals(role) : true)
                .OrderBy(x => x.CreateAt)
                .ToList();

            return Ok(_mapper.Map<ICollection<EmployeeDto>>(employees));
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] AddEmployeeDto value)
        {
            if (_employeeInvitationRepo.GetQueryableNoTracking()
                .Include(x => x.Employee)
                .FirstOrDefault(x => x.Employee.Email.Equals(value.Email)) != null)
                throw new AppException("Invitation is sent to this email");


            var invitation = new EmployeeInvitationEntity()
            {
                ExpiresAt = DateTime.Now.AddDays(10),
                Accepted = false,
                Token = _jwtExtension.GenerateTokenForInvitation(value.Email, value.Role),
                Employee = new UserEntity()
                {
                    Email = value.Email,
                    Role = value.Role,
                    FullName = value.FullName,
                    Gender = value.Gender,
                    EmployeeStatus = EmployeeInvitationConstants.Pending,
                    PhoneNumber = value.PhoneNumber,
                    CreateAt = DateTime.Now,
                    HashPassword = BCrypt.Net.BCrypt.HashPassword("123!@#"),
                }
            };

            _employeeInvitationRepo.Insert(invitation);

            return Ok(_mapper.Map<EmployeeDto>(invitation.Employee));
        }

        [HttpPost("Resend")]
        public IActionResult ResendInvitation([FromBody] AddEmployeeDto value)
        {
            var invitation = _employeeInvitationRepo
                .GetQueryable()
                .Include(x => x.Employee)
                .FirstOrDefault(x => x.Employee.Email.Equals(value.Email) && !x.IsDeleted && !x.Accepted)
                    ?? throw new AppException("Invitation does not exist");


            var token = _jwtExtension.GenerateTokenForInvitation(value.Email, value.Role);

            invitation.Token = token;
            invitation.ResentAt = DateTime.Now;
            invitation.LastUpdate = DateTime.Now;

            _employeeInvitationRepo.SaveChanges();

            //_emailSender.SendEmail(new EmailForm()
            //{
            //    FromEmail = "huy@social-v2.com",
            //    Subject = token,
            //    ToEmail = value.Email
            //});

            return Ok();
        }

        [HttpPost("accept")]
        public IActionResult AcceptInvitation([FromBody] AcceptInvitationDto value)
        {
            var claims = _jwtExtension.DecodeToken(value.Token)
                ?? throw new AppException("Token is null");

            var exp = claims?.FirstOrDefault(claim => claim.Type == "exp")?.Value
                ?? throw new AppException("Token is invalid");

            var expire = new DateTime(1970, 1, 1, 0, 0, 0, 0)
                .AddSeconds(long.Parse(exp));

            if (DateTime.Compare(DateTime.Now, expire) > 0)
                throw new AppException("Token is expire");

            var email = claims?.FirstOrDefault(claim => claim.Type == "email")?.Value
                ?? throw new AppException("Token is invalid");

            var role = claims?.FirstOrDefault(claim => claim.Type == "role")?.Value
                ?? throw new AppException("Token is invalid");

            var invitation = _employeeInvitationRepo
                .GetQueryable()
                .Include(x => x.Employee)
                .FirstOrDefault(x => x.Employee.Email.Equals(email) && !x.IsDeleted && !x.Accepted)
                    ?? throw new AppException("Invitation does not exist");

            invitation.Accepted = true;
            invitation.AcceptedAt = DateTime.Now;
            _employeeInvitationRepo.SaveChanges();

            invitation.Employee.HashPassword = BCrypt.Net.BCrypt.HashPassword(value.Password);
            invitation.Employee.EmployeeStatus = EmployeeInvitationConstants.Active;
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            //var invitation = _inviteRepo
            //    .GetQueryable()
            //    .FirstOrDefault(x => x.Id == id && !x.IsDeleted)
            //    ?? throw new AppException("Invitation does not exist");

            //_inviteRepo.Delete(invitation);
            return Ok();
        }
    }
}
