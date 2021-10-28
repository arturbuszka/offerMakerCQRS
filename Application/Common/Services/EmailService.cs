using OfferMakerForCggCQRS.Application.Common.Interfaces;
using OfferMakerForCggCQRS.Application.Common.Settings;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Common.Services
{
    public class EmailService : IEmailService
    {

        private readonly SmtpClientSettings _stmpSettings;
        private readonly NetworkSettings _networkSettings;

        public EmailService(SmtpClientSettings stmpSettings, NetworkSettings networkSettings)
        {
            _stmpSettings = stmpSettings;
            _networkSettings = networkSettings;
        }


        public async Task ChangePasswordMail(string mailTo, string securityStamp, string userId)
        {
            var url = GetPersonalUrlForClient(securityStamp, userId);

            string body = $"To change your password click here: {url}";
            string subject = "Change password";

            var mail = GetMessage(mailTo, body, subject);
            await SendEmail(mail);
        }


        public async Task ActivationMail(string mailTo, string securityStamp, string userId)
        {
            var url = GetPersonalUrl(securityStamp, userId);

            string body = $"Your activation link: {url}";
            string subject = "Activate your account";

            var mail = GetMessage(mailTo, body, subject);
            await SendEmail(mail);
        }

        private string GetPersonalUrl(string securityStamp, string userId) => 
            $"{_networkSettings.Protocol}://{_networkSettings.Host}:{_networkSettings.Port}/account/user/{securityStamp}/{userId}";


        private string GetPersonalUrlForClient(string securityStamp, string userId) =>
            $"localhost:4200/account/forgot/new/{securityStamp}/{userId}";


        private async Task SendEmail(MailMessage mail)
        {
            SmtpClient smtpClient = GetSmtpClient();
            await smtpClient.SendMailAsync(mail);
        }


        private SmtpClient GetSmtpClient()
        {
            NetworkCredential networkCredentials = new NetworkCredential()
            {
                Password = _stmpSettings.Password,
                UserName = _stmpSettings.UserName
            };

            return new SmtpClient()
            {
                Host = _stmpSettings.Host,
                Port = _stmpSettings.Port,
                EnableSsl = _stmpSettings.EnableSSL,
                UseDefaultCredentials = _stmpSettings.UseDefaultCredentials,
                Credentials = networkCredentials
            };
        }

        private MailMessage GetMessage(string mailTo, string body, string subject)
        {
            MailMessage mail = new()
            {
                Subject = subject,
                Body = body,
                From = new MailAddress(_stmpSettings.SenderAddress, _stmpSettings.SenderDisplayName)
            };

            mail.To.Add(mailTo);

            return mail;
        }
    }
}
