using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OfferMakerForCggCQRS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Clients.Queries.GetClientsList
{
    public class GetClientsListQueryHandler : IRequestHandler<GetClientsListQuery, IList<ClientsListVm>>
    {
        private readonly IOffermakerDbContext _context;
        private readonly IMapper _mapper;

        public GetClientsListQueryHandler(IOffermakerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<ClientsListVm>> Handle(GetClientsListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.Clients
                .ProjectTo<ClientsListVm>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return entities;
                
        }
    }
}
