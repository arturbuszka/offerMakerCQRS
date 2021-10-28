using AutoMapper;
using OfferMakerForCggCQRS.Application.Common.Mappings;
using OfferMakerForCggCQRS.Domain.Entities;

namespace OfferMakerForCggCQRS.Application.Products.Queries.GetProductDetail
{
    public class ProductMenuDetailDto : IMapFrom<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductMenuDetailDto>();
        }
    }
}
