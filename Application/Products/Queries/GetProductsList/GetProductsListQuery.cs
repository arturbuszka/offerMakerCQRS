using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Products.Queries.GetProductsList
{
    public class GetProductsListQuery : IRequest<IList<ProductsListVm>>
    {
    }
}
