using AutoMapper;
using MediatR;
using OfferMakerForCggCQRS.Application.Common.Exceptions;
using OfferMakerForCggCQRS.Domain.Entities;
using OfferMakerForCggCQRS.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Clients.Queries.GetClientDetail
{
    public class GetClientDetailQueryHandler : IRequestHandler<GetClientDetailQuery, ClientDetailVm>
    {
        private readonly IOffermakerDbContext _context;
        private readonly IMapper _mapper;

        public GetClientDetailQueryHandler(IOffermakerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ClientDetailVm> Handle(GetClientDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Clients.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Client), request.Id);
            }

           
            return _mapper.Map<ClientDetailVm>(entity);
        }
    }
}
