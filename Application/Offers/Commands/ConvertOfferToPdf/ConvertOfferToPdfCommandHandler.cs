using MediatR;
using OfferMakerForCggCQRS.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Offers.Commands.ConvertOfferToPdf
{
    public class ConvertOfferToPdfCommandHandler : IRequestHandler<ConvertOfferToPdfCommand>
    {
        private readonly IPdfConverter _pdfConverter;

        public ConvertOfferToPdfCommandHandler(IPdfConverter pdfConverter)
        {
            _pdfConverter = pdfConverter;
        }

        public async Task<Unit> Handle(ConvertOfferToPdfCommand request, CancellationToken cancellationToken)
        {
            var pdfFile = await Task.Run(() =>_pdfConverter.GeneratePdf(request.Id, request));

            return Unit.Value;
        }
    }
}
