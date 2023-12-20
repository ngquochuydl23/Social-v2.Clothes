namespace Social_v2.Clothes.Api.Extensions.EmailSender
{
    public interface IEmailSender
    {
        Task SendEmail(EmailForm form);
    }
}
