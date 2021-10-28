using AutoMapper;
using OfferMakerForCggCQRS.Application.Common.Mappings;
using OfferMakerForCggCQRS.Domain.Entities;

namespace OfferMakerForCggCQRS.Application.Products.Queries.GetProductDetail
{
    public class ProductDetailDto : IMapFrom<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal PriceEach { get; set; }
        public string Description { get; set; }
        public int OfferId { get; set; }
        public decimal PriceTotal { get => PriceEach * Quantity; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDetailDto>();
        }
    }
}
