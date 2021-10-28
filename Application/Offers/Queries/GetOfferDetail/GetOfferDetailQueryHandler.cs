using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OfferMakerForCggCQRS.Application.Common.Exceptions;
using OfferMakerForCggCQRS.Application.Common.Mappings;
using OfferMakerForCggCQRS.Domain.Entities;
using OfferMakerForCggCQRS.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Offers.Queries.GetOfferDetail
{
    public class GetOfferDetailQueryHandler : IRequestHandler<GetOfferDetailQuery, OfferDetailDto>
    {
        private readonly IOffermakerDbContext _context;
        private readonly IMapper _mapper;

        public GetOfferDetailQueryHandler(IOffermakerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OfferDetailDto> Handle(GetOfferDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Offers
                        .Include(p => p.Products)
                        .Include(c => c.Client)
                        .FirstOrDefaultAsync(o => o.Id == request.Id);
                

            if (entity == null)
            {
                throw new NotFoundException(nameof(Offer), request.Id);
            }

            return _mapper.Map<OfferDetailDto>(entity);
        }


    }
}
