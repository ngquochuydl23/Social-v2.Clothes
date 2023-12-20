using Mailjet.Client;
using Mailjet.Client.TransactionalEmails;
using System.Reflection.Metadata;

namespace Social_v2.Clothes.Api.Extensions.EmailSender
{
    public class EmailSenderImpl : IEmailSender
    {
        private readonly IMailjetClient _mailjetClient;

        public EmailSenderImpl(IMailjetClient mailjetClient)
        {


            _mailjetClient = mailjetClient;

        }

        public async Task SendEmail(EmailForm form)
        {
            var email = new TransactionalEmailBuilder()
               .WithFrom(new SendContact(form.FromEmail))
               .WithSubject(form.Subject)
               .WithHtmlPart("<h1>Header</h1>")
               .WithTo(new SendContact(form.ToEmail))
               .Build();

            await _mailjetClient.SendTransactionalEmailAsync(email);
        }
    }
}
