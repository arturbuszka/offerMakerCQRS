
namespace OfferMakerForCggCQRS.Application.Identity.Users.Commands.LoginUser
{
    public class AuthResponseModel
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
}
