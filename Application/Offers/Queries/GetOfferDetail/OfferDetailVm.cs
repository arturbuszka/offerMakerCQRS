using AutoMapper;
using OfferMakerForCggCQRS.Application.Offers.Queries.GetOfferDetail;
using OfferMakerForCggCQRS.Domain.Entities;
using System;
using System.Collections.Generic;

namespace OfferMakerForCggCQRS.Application.Common.Mappings
{
    public class OfferDetailVm : IMapFrom<Offer>
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public DateTime DateOfWork { get; set; }
        public string Description { get; set; }
        public List<NestedProductsDetailsVm> Products { get; set; }
        public DateTime Created { get; set; }
        public Client Client { get; set; }
        public int ProductsCount { get; set; }
        public decimal ProductsPrice { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Offer, OfferDetailVm>();
        }
    }
}
