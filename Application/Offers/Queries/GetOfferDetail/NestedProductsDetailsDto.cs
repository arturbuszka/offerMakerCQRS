using AutoMapper;
using OfferMakerForCggCQRS.Application.Common.Mappings;
using OfferMakerForCggCQRS.Domain.Entities;

namespace OfferMakerForCggCQRS.Application.Offers.Queries.GetOfferDetail
{
    public class NestedProductsDetailsDto : IMapFrom<Product>
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
            profile.CreateMap<Product, NestedProductsDetailsDto>();
        }
    }
}
