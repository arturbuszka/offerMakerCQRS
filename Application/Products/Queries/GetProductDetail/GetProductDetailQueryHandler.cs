using AutoMapper;
using MediatR;
using OfferMakerForCggCQRS.Application.Common.Exceptions;
using OfferMakerForCggCQRS.Application.Common.Mappings;
using OfferMakerForCggCQRS.Domain.Entities;
using OfferMakerForCggCQRS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Products.Queries.GetProductDetail
{


    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailVm>
    {
        private readonly IOffermakerDbContext _context;
        private readonly IMapper _mapper;

        public GetProductDetailQueryHandler(IOffermakerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDetailVm> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            return _mapper.Map<ProductDetailVm>(entity);
        }


    }
}
