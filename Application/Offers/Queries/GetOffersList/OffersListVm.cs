using AutoMapper;
using OfferMakerForCggCQRS.Application.Common.Mappings;
using OfferMakerForCggCQRS.Application.Common.Models;
using OfferMakerForCggCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Offers.Queries.GetOffersList
{
    public class OffersListVm : IMapFrom<Offer>
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public DateTime DateOfWork { get; set; }
        public string Description { get; set; }
        public List<NestedProductsListVm> Products { get; set; }
        public Client Client { get; set; }
        public DateTime Created { get; set; }
        public int ProductsCount { get; set; }
        public decimal ProductsPrice { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Offer, OffersListVm>();
        }
    }
}
