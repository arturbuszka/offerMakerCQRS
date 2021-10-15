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


    public class GetProductMenuDetailQueryHandler : IRequestHandler<GetProductMenuDetailQuery, ProductMenuDetailVm>
    {
        private readonly IOffermakerDbContext _context;
        private readonly IMapper _mapper;

        public GetProductMenuDetailQueryHandler(IOffermakerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductMenuDetailVm> Handle(GetProductMenuDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductsMenu
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductMenu), request.Id);
            }

            return _mapper.Map<ProductMenuDetailVm>(entity);
        }


    }
}
