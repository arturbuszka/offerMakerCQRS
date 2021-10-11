using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Offers.Commands.UpdateOfferCommand
{
    public class UpdateOfferCommand : IRequest
    {
        public int OfferId { get; set; }
        public string WorkCity { get; set; }
    }
}
