using AutoMapper;
using MediatR;
using OfferMakerForCggCQRS.Application.Common.Exceptions;
using OfferMakerForCggCQRS.Domain.Entities;
using OfferMakerForCggCQRS.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Products.Queries.GetProductDetail
{


    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailDto>
    {
        private readonly IOffermakerDbContext _context;
        private readonly IMapper _mapper;

        public GetProductDetailQueryHandler(IOffermakerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDetailDto> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            return _mapper.Map<ProductDetailDto>(entity);
        }
    }
}
