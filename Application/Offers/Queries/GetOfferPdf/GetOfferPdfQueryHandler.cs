using MediatR;
using OfferMakerForCggCQRS.Application.Common.Interfaces;
using OfferMakerForCggCQRS.Application.Common.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Offers.Queries.GetOfferPdf
{
    public class GetOfferPdfQueryHandler : IRequestHandler<GetOfferPdfQuery, PdfFileModel>
    {
        private readonly IPdfConverter _pdfConverter;

        public GetOfferPdfQueryHandler(IPdfConverter pdfConverter)
        {
            _pdfConverter = pdfConverter;
        }

        public async Task<PdfFileModel> Handle(GetOfferPdfQuery request, CancellationToken cancellationToken)
        {
            Console.WriteLine("yoyo");
            var fileContent = await  _pdfConverter.DownloadPdf(request.Id);
            
            return fileContent;

        }
    }
}
