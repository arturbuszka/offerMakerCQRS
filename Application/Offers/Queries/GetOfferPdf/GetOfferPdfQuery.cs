using MediatR;
using OfferMakerForCggCQRS.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Offers.Queries.GetOfferPdf
{
    public class GetOfferPdfQuery : IRequest<PdfFileModel>
    {
        public int Id { get; set; }
    }
}
