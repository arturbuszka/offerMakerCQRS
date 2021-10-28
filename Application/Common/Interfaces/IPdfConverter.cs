using OfferMakerForCggCQRS.Application.Common.Models;
using OfferMakerForCggCQRS.Application.Offers.Commands.ConvertOfferToPdf;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Common.Interfaces
{
    public interface IPdfConverter
    {
        string GeneratePdf(int id, ConvertOfferToPdfCommand offer);
        Task<PdfFileModel> DownloadPdf(int id);
    }
}
