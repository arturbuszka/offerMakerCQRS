using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Common.Settings
{
    public  class NetworkSettings
    {
        public string Protocol { get; set; } = "https";
        public string Host { get; set; } = "localhost";
        public  int  Port { get; set; } = 5001;
    }
}
