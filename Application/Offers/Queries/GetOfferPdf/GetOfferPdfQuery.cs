using MediatR;
using OfferMakerForCggCQRS.Application.Common.Models;

namespace OfferMakerForCggCQRS.Application.Offers.Queries.GetOfferPdf
{
    public class GetOfferPdfQuery : IRequest<PdfFileModel>
    {
        public int Id { get; set; }
    }
}
