using OfferMakerForCggCQRS.Domain.Common;
using System;
using System.Collections.Generic;

namespace OfferMakerForCggCQRS.Domain.Entities
{
    public class Offer : AuditableEntity
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public DateTime DateOfWork { get; set; }
        public string Description { get; set; }
        public int ProductsCount { get; set; }
        public decimal ProductsPrice { get; set; }
        public List<Product> Products { get; set; }
        public Client Client { get; set; }


    }
}
