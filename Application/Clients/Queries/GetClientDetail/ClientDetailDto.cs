using OfferMakerForCggCQRS.Domain.Entities;
using AutoMapper;
using OfferMakerForCggCQRS.Application.Common.Mappings;

namespace OfferMakerForCggCQRS.Application.Clients.Queries.GetClientDetail
{
    public class ClientDetailDto : IMapFrom<Client>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string Nip { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Client, ClientDetailDto>();
        }
    }
}
