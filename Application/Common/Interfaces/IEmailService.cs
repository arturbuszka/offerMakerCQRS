using OfferMakerForCggCQRS.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task ActivationMail(string mailTo, string url);
        string GetActivationUrl(string securityStamp, string userId);
    }
}
