using OfferMakerForCggCQRS.Application.Common.Interfaces;
using OfferMakerForCggCQRS.Application.Common.Models;
using OfferMakerForCggCQRS.Application.Common.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Common.Services
{
    public class EmailService : IEmailService
    {

        private readonly SmtpClientSettings _config;
        private readonly NetworkSettings _networkSettings;

        public EmailService(SmtpClientSettings config, NetworkSettings networkSettings)
        {
            _config = config;
            _networkSettings = networkSettings;
        }



        public async Task ChangePasswordMail(string mailTo, string securityStamp, string userId)
        {

            var url = GetPersonalUrl(securityStamp, userId);

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

        private string GetPersonalUrl(string securityStamp, string userId)
        {
            var url = $"{_networkSettings.Protocol}://{_networkSettings.Host}:{_networkSettings.Port}/account/user/{securityStamp}/{userId}";

            return url;
        }

        private async Task SendEmail(MailMessage mail)
        {
            SmtpClient smtpClient = GetSmtpClient();
            await smtpClient.SendMailAsync(mail);

        }


        private SmtpClient GetSmtpClient()
        {
            NetworkCredential networkCredentials = new NetworkCredential()
            {
                Password = _config.Password,
                UserName = _config.UserName
            };

            return new SmtpClient()
            {
                Host = _config.Host,
                Port = _config.Port,
                EnableSsl = _config.EnableSSL,
                UseDefaultCredentials = _config.UseDefaultCredentials,
                Credentials = networkCredentials
            };
        }

        private MailMessage GetMessage(string mailTo, string body, string subject)
        {
            MailMessage mail = new()
            {
                Subject = subject,
                Body = body,
                From = new MailAddress(_config.SenderAddress, _config.SenderDisplayName)
            };

            mail.To.Add(mailTo);

            return mail;
        }

        
    }
}
