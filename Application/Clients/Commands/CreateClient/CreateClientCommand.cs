using MediatR;

namespace OfferMakerForCggCQRS.Application.Clients.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string Nip { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
