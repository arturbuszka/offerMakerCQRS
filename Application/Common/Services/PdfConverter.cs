
using DinkToPdf;
using DinkToPdf.Contracts;
using OfferMakerForCggCQRS.Application.Common.Interfaces;
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

        public string GeneratePdf(int id, List<Product> products)
        {

            string fileName = $"{id}.pdf";
            string filePath = $@"C:\\dink\\{fileName}";

            string tableString = BuildHtmlTableString(products);

            var glb = BuildGlobalSettings(id, filePath);

            var objectSettings = BuildObjectSettings(tableString);

            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = glb,
                Objects = { objectSettings }
            };

            _convert.Convert(pdf);
            return filePath;


        }

        private static string BuildHtmlTableString(List<Product> products)
        {
            string stringBuilder = "";
            foreach (var p in products)
            {
                stringBuilder += $"<tr><td>{p.Name}</td><td>{p.Quantity}</td><td>{p.PriceEach}</td><td>p.PriceTotal</td><td>{p.Description}</td></tr>";
            }

            return stringBuilder;
        }

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

        private static ObjectSettings BuildObjectSettings(string htmlString)
        {
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = $"<table>{htmlString}</table>",
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = null }
            };

            return objectSettings;
        }

    }
}
