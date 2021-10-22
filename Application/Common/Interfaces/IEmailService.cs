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
        Task ChangePasswordMail(string mailTo, string securityStamp, string userId);
        Task ActivationMail(string mailTo, string securityStamp, string userId);
    }
}
