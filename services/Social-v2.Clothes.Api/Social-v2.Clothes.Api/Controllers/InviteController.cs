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

namespace Social_v2.Clothes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InviteController : BaseController
    {
        private readonly IEmailSender _emailSender;
        private readonly IJwtExtension _jwtExtension;
        private readonly IRepository<InviteEntity> _inviteRepo;
        private readonly IRepository<UserEntity> _userRepo;
        private readonly IMapper _mapper;

        public InviteController(
            IMapper mapper,
            IRepository<InviteEntity> inviteRepo,
            IRepository<UserEntity> userRepo,
            IEmailSender emailSender,
            IJwtExtension jwtExtension,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _inviteRepo = inviteRepo;
            _userRepo = userRepo;
            _emailSender = emailSender;
            _jwtExtension = jwtExtension;
        }

        [HttpGet]
        public IActionResult GetInvitations(
            [FromQuery] bool? isAccepted,
            [FromQuery] string? role,
            [FromQuery] bool? isExpired)
        {

            var invitations = _inviteRepo
                .GetQueryableNoTracking()
                .Where(x => !x.IsDeleted)
                .Where(x => isAccepted.HasValue ? x.Accepted == isAccepted : true)
                .Where(x => !string.IsNullOrEmpty(role) ? x.Role.Equals(role) : true)
                .Where(x => isExpired.HasValue ? DateTime.Compare(DateTime.Now, x.ExpiresAt) > 0 == isExpired.Value : true)
                .ToList();
            return Ok(_mapper.Map<ICollection<InviteDto>>(invitations));
        }

        [HttpPost]
        public IActionResult AddNewInvite([FromBody] AddNewInviteDto value)
        {
            if (_inviteRepo.GetQueryableNoTracking()
                .FirstOrDefault(x => x.Email.Equals(value.Email)) != null)
                throw new AppException("Invitation is sent to this email");

            var token = _jwtExtension.GenerateTokenForInvitation(value.Email, value.Role);
            var invitation = _inviteRepo.Insert(new InviteEntity()
            {
                Email = value.Email,
                Role = value.Role,
                Token = token,
                Accepted = false,
                ExpiresAt = DateTime.Now.AddDays(10)
            });

            _emailSender.SendEmail(new EmailForm()
            {
                FromEmail = "huy@social-v2.com",
                Subject = token,
                ToEmail = value.Email
            });

            return Ok(_mapper.Map<InviteDto>(invitation));
        }

        [HttpPost("Resend")]
        public IActionResult ResendInvitation([FromBody] AddNewInviteDto value)
        {
            var invitation = _inviteRepo
                .GetQueryable()
                .FirstOrDefault(x => x.Email.Equals(value.Email))
                    ?? throw new AppException("Invitation does not exist");


            var token = _jwtExtension.GenerateTokenForInvitation(value.Email, value.Role);

            invitation.Token = token;
            invitation.ResentAt = DateTime.Now;
            invitation.LastUpdate = DateTime.Now;

            _inviteRepo.SaveChanges();

            _emailSender.SendEmail(new EmailForm()
            {
                FromEmail = "huy@social-v2.com",
                Subject = token,
                ToEmail = value.Email
            });

            return Ok(_mapper.Map<InviteDto>(invitation));
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

            var invitation = _inviteRepo
                .GetQueryable()
                .FirstOrDefault(x => x.Email.Equals(email) && !x.IsDeleted)
                ?? throw new AppException("Invitation does not exist");

            invitation.Accepted = true;
            invitation.AcceptedAt = DateTime.Now;
            _inviteRepo.SaveChanges();

            var user = _userRepo.Insert(new UserEntity()
            {
                Email = email,
                Role = role,
                Birthday = value.User.Birthday,
                FullName = value.User.FullName,
                Gender = value.User.Gender,
                PhoneNumber = value.User.PhoneNumber,
                HashPassword = BCrypt.Net.BCrypt.HashPassword(value.User.Password),
            });
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var invitation = _inviteRepo
                .GetQueryable()
                .FirstOrDefault(x => x.Id == id && !x.IsDeleted)
                ?? throw new AppException("Invitation does not exist");

            _inviteRepo.Delete(invitation);
            return Ok();
        }
    }
}
