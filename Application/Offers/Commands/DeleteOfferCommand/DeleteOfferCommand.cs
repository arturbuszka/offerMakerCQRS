using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Offers.Commands.DeleteOfferCommand
{
    public class DeleteOfferCommand : IRequest
    {
        public int Id { get; set; }
    }
}
