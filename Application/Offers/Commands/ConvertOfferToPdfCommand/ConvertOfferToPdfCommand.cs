using MediatR;
using OfferMakerForCggCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Offers.Commands.ConvertOfferToPdfCommand
{
    public class ConvertOfferToPdfCommand : IRequest<string>
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public DateTime DateOfWork { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
        public Client Client { get; set; }
    }
}
