namespace Social_v2.Clothes.Api.Dtos.Invites
{
    public class AcceptInvitationDto
    {
        public string Token { get; set; }

        public CreateUserFromInviteDto User { get; set; }
    }
}
