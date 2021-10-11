using MediatR;
using OfferMakerForCggCQRS.Application.Common.Models;
using OfferMakerForCggCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Offers.Queries.GetOffersList
{
    public class GetOffersListQuery : IRequest<PagedResult<OffersListVm>>
    {
        public PaginationQuery Pagination { get; set; }
        public int Id { get; set; }
    }
}
