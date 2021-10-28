using MediatR;
using System.Collections.Generic;


namespace OfferMakerForCggCQRS.Application.Products.Queries.GetProductsList
{
    public class GetProductsListQuery : IRequest<IList<ProductsListDto>>
    {
    }
}
