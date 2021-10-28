
namespace OfferMakerForCggCQRS.Application.Common.Settings
{
    public  class NetworkSettings
    {
        public string Protocol { get; set; } = "https";
        public string Host { get; set; } = "localhost";
        public  int  Port { get; set; } = 5001;
    }
}
