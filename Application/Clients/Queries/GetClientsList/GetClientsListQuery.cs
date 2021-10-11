using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Clients.Queries.GetClientsList
{
    public class GetClientsListQuery : IRequest<IList<ClientsListVm>>
    {
    }
}
