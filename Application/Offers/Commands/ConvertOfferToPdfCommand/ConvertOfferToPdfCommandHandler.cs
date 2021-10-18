using MediatR;
using OfferMakerForCggCQRS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Offers.Commands.ConvertOfferToPdfCommand
{
    public class ConvertOfferToPdfCommandHandler : IRequestHandler<ConvertOfferToPdfCommand, string>
    {
        private readonly IPdfConverter _pdfConverter;

        public ConvertOfferToPdfCommandHandler(IPdfConverter pdfConverter)
        {
            _pdfConverter = pdfConverter;
        }

        public async Task<string> Handle(ConvertOfferToPdfCommand request, CancellationToken cancellationToken)
        {
            var pdfFile = await Task.Run(() =>_pdfConverter.GeneratePdf(request.Id, request));

            return "Ok";
        }
    }
}
