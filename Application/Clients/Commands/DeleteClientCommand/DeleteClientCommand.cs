using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Clients.Commands.DeleteClientCommand
{
    public class DeleteClientCommand : IRequest
    {
        public int ClientId { get; set; }
    }
}
