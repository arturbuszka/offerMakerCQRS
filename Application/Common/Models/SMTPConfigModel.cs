﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Common.Models
{
    public class SMTPConfigModel
    {
        public string SenderAddress { get; set; }
        public string SenderDisplayName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSSL { get; set; } = true;
        public bool UseDefaultCredentials { get; set; } = false;
        public bool IsBodyHTML { get; set; } = true;
    }
}
