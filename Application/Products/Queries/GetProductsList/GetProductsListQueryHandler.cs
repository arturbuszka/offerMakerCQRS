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

namespace OfferMakerForCggCQRS.Application.Products.Queries.GetProductsList
{


    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, IList<ProductsListDto>>
    {
        private readonly IOffermakerDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsListQueryHandler(IOffermakerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<ProductsListDto>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.Products
                .ProjectTo<ProductsListDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return entities;

        }
    }
}
