using MediatR;
using System.Collections.Generic;


namespace OfferMakerForCggCQRS.Application.Clients.Queries.GetClientsList
{
    public class GetClientsListQuery : IRequest<IList<ClientsListDto>>
    {
    }
}
