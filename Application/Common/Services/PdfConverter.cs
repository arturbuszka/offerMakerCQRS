
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.StaticFiles;
using OfferMakerForCggCQRS.Application.Common.Interfaces;
using OfferMakerForCggCQRS.Application.Common.Models;
using OfferMakerForCggCQRS.Application.Common.Settings;
using OfferMakerForCggCQRS.Application.Offers.Commands.ConvertOfferToPdfCommand;
using OfferMakerForCggCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Common.Services
{

    public class PdfConverter : IPdfConverter
    {
        private readonly IConverter _convert;

        public PdfConverter(IConverter convert)
        {
            _convert = convert;
        }

        public string GeneratePdf(int id, ConvertOfferToPdfCommand offer)
        {

            
            string fileName = $"{id}.pdf";
            string filePath = FilesSettings.FilePath+fileName;

            //string tableString = BuildHtmlTableString(offer.Products);

            var glb = BuildGlobalSettings(id, filePath);

            var objectSettings = BuildObjectSettings(offer);

            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = glb,
                Objects = { objectSettings }
            };

            _convert.Convert(pdf);
            return filePath;

        }
        public async Task<PdfFileModel> DownloadPdf(int id)
        {
            var filePath = FilesSettings.FilePath + $"{id}.pdf";
            var memory = new MemoryStream();
            await using(var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            PdfFileModel file = new(memory, GetContentType(filePath), filePath);
            return file;
        }

        //private static string BuildHtmlTableString(List<ProductModel> products)
        //{
        //    string stringBuilder = "";
        //    foreach (var p in products)
        //    {
        //        p.ToString();
        //        stringBuilder += $"<tr><td>Count</td><td>{p.Name}</td><td>{p.Quantity}</td><td>{p.PriceEach}</td><td>{p.PriceTotal}</td><td>{p.Description}</td></tr>";
        //    }

        //    return stringBuilder;
        //}

        private static GlobalSettings BuildGlobalSettings(int id, string filePath)
        {
            var glb = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Landscape,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings()
                {
                    Bottom = 20,
                    Left = 20,
                    Right = 20,
                    Top = 30
                },
                DocumentTitle = $"Zlecenie_nr{id}",
                Out = filePath
            };

            return glb;
        }

        private static ObjectSettings BuildObjectSettings(ConvertOfferToPdfCommand offer)
        {
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = HtmlTemplateBuilder.HtmlStringBuilder(offer),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.GetFullPath(@"D:\download\offerMakerCQRS-main\offerMakerCQRS-main\Application\Common\Settings\CssSettings.css") }
            };

            return objectSettings;
        }
        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;

            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }

            return contentType;
        }

    }
}
