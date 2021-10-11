

namespace OfferMakerForCggCQRS.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal PriceEach { get; set; }
        public string Description { get; set; }
        public int OfferId { get; set; }
    }
}
