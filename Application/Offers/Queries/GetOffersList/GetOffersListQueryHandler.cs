using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OfferMakerForCggCQRS.Application.Common.Models;
using OfferMakerForCggCQRS.Domain.Entities;

using OfferMakerForCggCQRS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Offers.Queries.GetOffersList
{
    public class GetOffersListQueryHandler : IRequestHandler<GetOffersListQuery, PagedResult<OffersListVm>>
    {
        private readonly IOffermakerDbContext _context;
        private readonly IMapper _mapper;

        public GetOffersListQueryHandler(IOffermakerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedResult<OffersListVm>> Handle(GetOffersListQuery request, CancellationToken cancellationToken)
        {





            var paginationVariable = request.Pagination;

            var baseQuery = _context
             .Offers
             .Include(p => p.Products)
             .Include(c => c.Client)
             .AsQueryable()
             .Where(s => paginationVariable.SearchPhrase == null || (s.City.ToLower().Contains(paginationVariable.SearchPhrase.ToLower())));







            if (!string.IsNullOrEmpty(paginationVariable.SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<Offer, object>>>
                {
                    { nameof(Offer.Created), o => o.Created }
                };

                var selectedColumn = columnsSelectors[paginationVariable.SortBy];

                baseQuery = paginationVariable.SortDirection == SortDirection.ASC
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }
            
            var offers =  await baseQuery
             .ProjectTo<OffersListVm>(_mapper.ConfigurationProvider)
             .Skip(paginationVariable.PageSize * (paginationVariable.PageNumber - 1))
             .Take(paginationVariable.PageSize)
             .ToListAsync(cancellationToken);

            var totalItemsCount =  await baseQuery.CountAsync();


            var result = new PagedResult<OffersListVm>(offers, totalItemsCount, paginationVariable.PageSize, paginationVariable.PageNumber);
  

            return result;
        }
    }
}
