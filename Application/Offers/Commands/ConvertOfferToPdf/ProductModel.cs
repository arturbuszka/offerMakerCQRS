using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Offers.Commands.ConvertOfferToPdf
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string PriceEach { get; set; }
        public string PriceTotal { get; set; }
        public string Description { get; set; }
        public int OfferId { get; set; }
    }
}
