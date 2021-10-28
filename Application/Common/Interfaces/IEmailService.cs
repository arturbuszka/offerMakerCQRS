using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task ChangePasswordMail(string mailTo, string securityStamp, string userId);
        Task ActivationMail(string mailTo, string securityStamp, string userId);
    }
}
