using MediatR;
using OfferMakerForCggCQRS.Domain.Entities;
using System;
using System.Collections.Generic;

namespace OfferMakerForCggCQRS.Application.Offers.Commands
{
    public class CreateOfferCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public DateTime DateOfWork { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public int ProductsCount { get; set; }
        public decimal ProductsPrice { get; set; }
    }
}
