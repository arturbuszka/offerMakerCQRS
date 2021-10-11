

namespace OfferMakerForCggCQRS.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public int Nip { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
