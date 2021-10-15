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


    public class GetProductsMenuListQueryHandler : IRequestHandler<GetProductsMenuListQuery, IList<ProductsMenuListVm>>
    {
        private readonly IOffermakerDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsMenuListQueryHandler(IOffermakerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<ProductsMenuListVm>> Handle(GetProductsMenuListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.ProductsMenu
                .ProjectTo<ProductsMenuListVm>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return entities;

        }
    }
}
