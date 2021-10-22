using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Common.Settings
{
    public class SmtpClientSettings
    {
        public string SenderAddress { get; set; } = "no-reply@cgg.com";
        public string SenderDisplayName { get; set; } = "CGG";
        public string UserName { get; set; } = "5dc3d502f19b8f";
        public string Password { get; set; } = "18257f1e9c8c97";
        public string Host { get; set; } = "smtp.mailtrap.io";
        public int Port { get; set; } = 2525;
        public bool EnableSSL { get; set; } = true;
        public bool UseDefaultCredentials { get; set; } = false;
        public bool IsBodyHTML { get; set; } = true;
    }
}
